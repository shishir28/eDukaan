namespace Razor.UI.Models
{
    public class ApplicationUserModel
    {
        public string Id { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }

        public string SecurityNumber { get; set; }
        public string Expiration { get; set; }
        public string CardHolderName { get; set; }
        public string PhoneNumber { get; set; }

        public int CardType { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

}
