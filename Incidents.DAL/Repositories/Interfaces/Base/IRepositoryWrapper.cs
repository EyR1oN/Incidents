namespace Incidents.DAL.Repositories.Interfaces.Base
{
    public interface IRepositoryWrapper
    {
        IAccountRepository AccountRepository { get; }
        IIncidentRepository IncidentRepository { get; }
        IContactRepository ContactRepository { get; }

        public int SaveChanges();

        public Task<int> SaveChangesAsync();
    }
}
