using AuthJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Services.Interfaces
{
    public interface IConnectionService
    {
        public void LoginUser(ApplicationUser user);
        public void LogoutUser(string name);
        public IEnumerable<ApplicationUser> GetUsersByRole(string role);
    }
}
