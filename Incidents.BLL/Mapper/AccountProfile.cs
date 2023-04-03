using AutoMapper;
using Incidents.BLL.DTO;
using Incidents.DAL.Entities;

namespace Incidents.BLL.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>().ForPath(q => q.Contacts, conf => conf.Ignore());
            CreateMap<AccountDTO, Account>();
        }
    }
}
