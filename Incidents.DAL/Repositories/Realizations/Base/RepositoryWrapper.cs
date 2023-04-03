using Incidents.DAL.Entities;
using Incidents.DAL.Repositories.Interfaces;
using Incidents.DAL.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidents.DAL.Repositories.Realizations.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _dataContext;

        private IAccountRepository _accountRepository;

        private IIncidentRepository _incidentRepository;

        private IContactRepository _contactRepository;

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository is null)
                {
                    _accountRepository = new AccountRepository(_dataContext);
                }
                return _accountRepository;
            }
        }

        public IIncidentRepository IncidentRepository
        {
            get
            {
                if (_incidentRepository is null)
                {
                    _incidentRepository = new IncidentRepository(_dataContext);
                }
                return _incidentRepository;
            }
        }

        public IContactRepository ContactRepository
        {
            get
            {
                if (_contactRepository is null)
                {
                    _contactRepository = new ContactRepository(_dataContext);
                }
                return _contactRepository;
            }
        }

        public RepositoryWrapper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
