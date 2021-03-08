﻿using Microsoft.AspNetCore.Identity;

namespace AuthJWT.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
    }
}