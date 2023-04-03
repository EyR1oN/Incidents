using Microsoft.EntityFrameworkCore;

namespace Incidents.DAL.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IncidentId { get; set; }
        public Incident? Incident { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
