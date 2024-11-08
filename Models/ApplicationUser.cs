﻿using Microsoft.AspNetCore.Identity;

namespace AutorizationAunthentication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public string FullName => $"{FirstName} {LastName}";
    }
}
