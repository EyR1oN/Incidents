using Incidents.DAL.CustomAttributes;

namespace Incidents.BLL.DTO
{
    public class IncidentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ValidateCountGreaterThanZero(ErrorMessage = "At least one account is required.")]
        public List<AccountDTO> Accounts { get; set; }
    }
}
