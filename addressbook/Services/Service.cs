using AddressBook.Data;
using AddressBook.Models;
using AutoMapper;
using System.Text.RegularExpressions;

namespace AddressBook.Services
{
    public class Service
    {
        private DbContext DB;
        private IMapper Mapper;
        public Service(DbContext db,IMapper mapper)
        {
            DB = db;
            Mapper = mapper;
        }
        public IEnumerable<ContactDetailsViewModel> GetAllContactsList()
        {
            IEnumerable<ContactDetails> contactListFromDB = DB.GetAllContacts();
            IEnumerable<ContactDetailsViewModel> contactListToView=Mapper.Map<IEnumerable<ContactDetailsViewModel>>(contactListFromDB);
            return contactListToView;
        }
        public void AddContactToList(ContactDetailsViewModel contact)
        {
            ContactDetails contactItem=Mapper.Map<ContactDetails>(contact);
            DB.AddContact(contactItem);
        }
        public ContactDetailsViewModel GetContactFromContactList(int id) {
            ContactDetails contact = DB.GetContactItem(id);
            ContactDetailsViewModel contactItem=Mapper.Map<ContactDetailsViewModel>(contact);
            return contactItem;
        }
        public void UpdateContactInContactList(ContactDetailsViewModel contact)
        {
            ContactDetails contactItem = Mapper.Map<ContactDetails>(contact);
            DB.UpdateContact(contactItem);
        }
        public void DeleteContactFromContactList(int id)
        {
            DB.RemoveContact(id);
        }
        public ContactDetailsViewModel GetLastContact()
        {
            ContactDetailsViewModel contact = Mapper.Map<ContactDetailsViewModel>(DB.GetAllContacts().Last());
            return contact ;
        }
        public int GetIdOfContact(ContactDetailsViewModel contact)
        {
            ContactDetails contactItem = Mapper.Map<ContactDetails>(contact);
            return contactItem.ID;
        }
    }
}
