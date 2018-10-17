using Microsoft.AspNetCore.Identity;
using Monad.EDukaan.Framework.Common.Entities;
using System;

namespace Monad.EDukaan.Service.Identity.Domain.Entities.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public int AccessFailedCount { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int CardType { get; set; }
        public string City { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Expiration { get; set; }
        public string LastName { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime LockoutEnd { get; set; }
        public string Name { get; set; }
        public string NormalizedEmail { get; set; }        
        public string NormalizedUserName { get; set; }        
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityNumber { get; set; }        
        public string SecurityStamp { get; set; }        
        public string State { get; set; }
        public string Street { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; } 
        public string ZipCode { get; set; }        
    }
}