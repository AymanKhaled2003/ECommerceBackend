using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Options;
using Microsoft.Extensions.Options;

namespace ECommerce.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtOptions _options;


        public AuthenticationService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration, IOptions<JwtOptions> options)
        {
            _userManager = userManager;
            _configuration = configuration;
            _options = options.Value;
        }
        public async Task<ApplicationUser> AuthenticateAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return null;
            }
            var isValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (isValidPassword)
            {
                return user;
            }

            return null;
        }


        public async Task<string> Generate(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new(JwtRegisteredClaimNames.UniqueName, user.UserName ?? "")
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience, // لو مش مستخدمها، شيل السطر ده
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
