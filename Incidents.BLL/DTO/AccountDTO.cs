using Incidents.DAL.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace Incidents.BLL.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int IncidentId { get; set; }

        [ValidateCountGreaterThanZero(ErrorMessage = "At least one account is required.")]
        public List<ContactDTO> Contacts { get; set; }
    }
}
