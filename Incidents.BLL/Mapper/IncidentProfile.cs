using AutoMapper;
using Incidents.BLL.DTO;
using Incidents.DAL.Entities;

namespace Incidents.BLL.Mapper
{
    public class IncidentProfile : Profile
    {
        public IncidentProfile()
        {
            CreateMap<Incident, IncidentDTO>().ReverseMap();
        }
    }
}
