using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string ZipCode { get; set; }
    }
    public class ContactDetailsViewModel
    {
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9.]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "You have entered an invalid email")]
        public string UserEmail { get; set; }

        [Required]
        public string UserMobile { get; set; }

        public string UserLandLine { get; set; }

        public string UserWebsite { get; set; }

        public Address Address { get; set; }
    }
}
