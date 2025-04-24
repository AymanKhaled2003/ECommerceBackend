using Common.Application.Abstractions.Messaging;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;
using MediatR;
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

namespace ECommerce.Application.Features.Auth.Command.Register
{

    public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration; 
        private readonly IAuthenticationService _authService;


        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration, IAuthenticationService authService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _authService = authService;
        }

        public async Task<ResponseModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return  ResponseModel.Failure($"Registration failed: {errors}");
            }

            var token = _authService.Generate(user);


            return ResponseModel.Success();
        }
    }

}
