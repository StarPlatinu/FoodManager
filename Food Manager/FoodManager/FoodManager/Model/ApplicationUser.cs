﻿using Microsoft.AspNetCore.Identity;

namespace FoodManager.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
