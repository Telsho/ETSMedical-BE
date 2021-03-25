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
        public IEnumerable<UserHub> GetUsersByRole(string role)
        {
            return Connections.Users.Select(u => u.Value).Where(u => u.Role == role).ToArray();
        }
        public IEnumerable<UserHub> GetAllUsers()
        {
            return Connections.Users.Select(u => u.Value).ToArray();
        }

        public void LoginUser(UserHub user)
        {
            Connections.Users.AddOrUpdate(user.UserName, user, (k , v) => user);
        }

        public UserHub LogoutUser(string name)
        {
            UserHub value;
            Connections.Users.TryRemove(name, out value);

            return value;
        }

        public UserHub GetUserByName(string name)
        {
            UserHub user;
            if (Connections.Users.TryGetValue(name, out user))
                return user;
            else
                throw new Exception("Can't find user " + name);
        }
    }
}

public static class Connections
{
    static Connections()
    {
        Users = new ConcurrentDictionary<string, UserHub>();
    }

    public static ConcurrentDictionary<string,UserHub> Users{ get; set; }
}
