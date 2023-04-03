using AutoMapper;
using Incidents.BLL.DTO;
using Incidents.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incidents.BLL.Mapper
{
    public class InfoProfile : Profile
    {
        public InfoProfile()
        {
            CreateMap<Account, InfoDTO>()
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ContactFirstName, opt => opt.MapFrom(src => src.Contacts.FirstOrDefault().FirstName))
                .ForMember(dest => dest.ContactLastName, opt => opt.MapFrom(src => src.Contacts.FirstOrDefault().LastName))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.Contacts.FirstOrDefault().Email))
                .ForMember(dest => dest.IncidentDescription, opt => opt.MapFrom(src => src.Incident.Description))
                .ReverseMap();

            CreateMap<InfoDTO, Contact>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ContactFirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ContactLastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactEmail))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }

}
