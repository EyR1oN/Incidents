using Incidents.DAL.Entities;
using Incidents.DAL.Repositories.Interfaces;
using Incidents.DAL.Repositories.Realizations.Base;

namespace Incidents.DAL.Repositories.Realizations
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(DataContext dbContext)
        : base(dbContext)
        {
        }

    }
}
