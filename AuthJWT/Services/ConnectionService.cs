using AuthJWT.Models;
using AuthJWT.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AuthJWT.Services
{
    public class ConnectionService : IConnectionService
    {
        public IEnumerable<ApplicationUser> GetUsersByRole(string role)
        {
            return Connections.Users.Select(u => u.Value).Where(u => u.Role == role);
        }

        public void LoginUser(ApplicationUser user)
        {
            Connections.Users.GetOrAdd(user.UserName, user);
        }

        public void LogoutUser(string name)
        {
            var value = Connections.Users.Select(u => u.Value).Where(v => v.UserName == name).First();
            Connections.Users.TryRemove(name, out value);
        }
    }
}

public static class Connections
{
    static Connections()
    {
        Users = new ConcurrentDictionary<string, ApplicationUser>();
    }

    public static ConcurrentDictionary<string,ApplicationUser> Users{ get; set; }
}
