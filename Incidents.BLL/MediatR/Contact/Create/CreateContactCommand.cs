using FluentResults;
using Incidents.BLL.DTO;
using MediatR;

namespace Incidents.BLL.MediatR.Contact.Create
{
    public record CreateContactCommand(InfoDTO Info) : IRequest<Result<Unit>>;
}
