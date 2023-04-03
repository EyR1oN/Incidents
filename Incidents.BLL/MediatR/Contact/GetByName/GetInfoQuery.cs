using FluentResults;
using Incidents.BLL.DTO;
using MediatR;

namespace Incidents.BLL.MediatR.Contact.GetByName
{
    public record GetInfoQuery(string Name) : IRequest<Result<InfoDTO>>;
}
