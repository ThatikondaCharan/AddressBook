using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class ContactDetails
    {
       
        public int ID { get; set; }
 
        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string LandLine { get; set; }

        public string Website { get; set; }

        public string Address { get; set; }

    }
}
