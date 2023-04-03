using Incidents.DAL.Entities;
using Incidents.DAL.Repositories.Interfaces;
using Incidents.DAL.Repositories.Realizations.Base;

namespace Incidents.DAL.Repositories.Realizations
{
    public class IncidentRepository : RepositoryBase<Incident>, IIncidentRepository
    {
        public IncidentRepository(DataContext dbContext)
        : base(dbContext)
        {
        }
    }
}
