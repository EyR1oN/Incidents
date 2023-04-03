using AutoMapper;
using FluentResults;
using Incidents.DAL.Repositories.Interfaces.Base;
using MediatR;
using Incidents.DAL.Entities;

namespace Incidents.BLL.MediatR.Incident.Create;

public class CreateIncidentHandler : IRequestHandler<CreateIncidentCommand, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public CreateIncidentHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
    {
        var incident = _mapper.Map<DAL.Entities.Incident>(request.Incident);

        if (incident is null)
        {
            return Result.Fail(new Error("Cannot convert null to Incident"));
        }

        await _repositoryWrapper.IncidentRepository.CreateAsync(incident);

        var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;
        return resultIsSuccess ? Result.Ok(Unit.Value) : Result.Fail(new Error("Failed to create a incident"));
    }
}