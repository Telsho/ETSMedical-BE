using AuthJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Services.Interfaces
{
    public interface IConnectionService
    {
        public void LoginUser(UserHub user);
        public UserHub LogoutUser(string name);
        public IEnumerable<UserHub> GetUsersByRole(string role);
        public IEnumerable<UserHub> GetAllUsers();
        public UserHub GetUserByName(string name);
    }
}
