using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Interfaces
{
    public interface ITokenExtractor
    {
        Guid GetUserId();
        string GetUserRole();
        string GetEmail();
        string GetUsername();
        List<string> GetPermissions();
        bool IsUserAuthenticated();
    }

}
