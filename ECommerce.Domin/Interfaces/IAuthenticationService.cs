using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateJwtToken(ApplicationUser user);
        Task<ApplicationUser> AuthenticateAsync(string username, string password);
    }
}
