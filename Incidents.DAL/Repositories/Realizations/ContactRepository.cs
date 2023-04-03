using Incidents.DAL.Entities;
using Incidents.DAL.Repositories.Interfaces;
using Incidents.DAL.Repositories.Realizations.Base;

namespace Incidents.DAL.Repositories.Realizations
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(DataContext dbContext)
        : base(dbContext)
        {
        }
    }
}
