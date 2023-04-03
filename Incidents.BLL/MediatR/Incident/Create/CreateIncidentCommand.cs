using FluentResults;
using Incidents.BLL.DTO;
using MediatR;

namespace Incidents.BLL.MediatR.Incident.Create
{
    public record CreateIncidentCommand(IncidentDTO Incident) : IRequest<Result<Unit>>;
}
