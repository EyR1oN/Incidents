using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Incidents.DAL.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
