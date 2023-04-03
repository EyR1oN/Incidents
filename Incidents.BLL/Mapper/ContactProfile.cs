using AutoMapper;
using Incidents.BLL.DTO;
using Incidents.DAL.Entities;

namespace Incidents.BLL.Mapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}