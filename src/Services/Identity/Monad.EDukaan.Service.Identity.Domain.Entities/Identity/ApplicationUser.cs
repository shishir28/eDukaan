using Microsoft.AspNetCore.Identity;
using Monad.EDukaan.Framework.Common.Entities;
using System;

namespace Monad.EDukaan.Service.Identity.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int CardType { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Expiration { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string SecurityNumber { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
}