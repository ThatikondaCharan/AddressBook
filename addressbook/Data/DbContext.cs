using AddressBook.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AddressBook.Data
{
    public class DbContext
    {
        private IDbConnection DB;
        public DbContext(IConfiguration configuration)
        {
            DB= new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public IEnumerable<ContactDetails> GetAllContacts()
        {
            var sql = "SELECT * FROM Contact";
            IEnumerable<ContactDetails> ContactList = DB.Query<ContactDetails>(sql);
            return ContactList;
        }
        public void AddContact(ContactDetails contact)
        {
            var sql = "INSERT INTO Contact(Name,Email,Mobile,LandLine,Website,Address) VALUES (@Name,@Email,@Mobile,@LandLine,@Website,@Address);";
            DB.Query<ContactDetails>(sql, new { @Name = contact.Name, @Email = contact.Email, @Mobile = contact.Mobile, @LandLine = contact.LandLine, @Website = contact.Website, @Address = contact.Address });

        }
        public void RemoveContact(int id)
        {
            var sql = "DELETE FROM Contact WHERE ID=@id";
            DB.Query<ContactDetails>(sql, new { @id = id });
        }
        public void UpdateContact(ContactDetails contact)
        {
            var sql = "UPDATE Contact SET Name=@Name,Email=@Email,Mobile=@Mobile,LandLine=@LandLine,Website=@Website,Address=@Address WHERE ID=@id";
            DB.Query<ContactDetails>(sql, new { @Name = contact.Name, @Email = contact.Email, @Mobile = contact.Mobile, @LandLine = contact.LandLine, @Website = contact.Website, @Address = contact.Address, @id = contact.ID });
        }
        public ContactDetails GetContactItem(int id)
        {
            var sql = "SELECT * FROM Contact WHERE ID=@id";
            ContactDetails contact = DB.Query<ContactDetails>(sql, new { @id = id }).Single();
            return contact;
        }
    }
}
