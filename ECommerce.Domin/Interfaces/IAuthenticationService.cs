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
        Task<string> Generate(ApplicationUser user);
      Task<ApplicationUser> AuthenticateAsync(string email, string password);
    }
}
