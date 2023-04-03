using AutoMapper;
using FluentResults;
using Incidents.DAL.Repositories.Interfaces.Base;
using MediatR;
using Incidents.DAL.Entities;
using Incidents.BLL.CustomErrors;

namespace Incidents.BLL.MediatR.Contact.Create;

public class CreateContactHandler : IRequestHandler<CreateContactCommand, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public CreateContactHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var account = await _repositoryWrapper.AccountRepository
            .GetFirstOrDefaultAsync(a => a.Name == request.Info.AccountName);

        if (account is null)
        {
            return Result.Fail(new NotFound($"Cannot find account with name {request.Info.AccountName}"));
        }

        var contact = await _repositoryWrapper.ContactRepository
            .GetFirstOrDefaultAsync(a => a.Email == request.Info.ContactEmail);

        if (contact is null) 
        {
            contact = _mapper.Map<DAL.Entities.Contact>(request.Info);
            contact.AccountId = account.Id;

            if (contact is null)
            {
                return Result.Fail(new Error("Cannot convert null to Incident"));
            }

            await _repositoryWrapper.ContactRepository.CreateAsync(contact);
            var incident = new DAL.Entities.Incident()
            {
                Description = request.Info.IncidentDescription
            };

            await _repositoryWrapper.IncidentRepository.CreateAsync(incident);

            var resultIsSuccessFirst = await _repositoryWrapper.SaveChangesAsync() > 0;

            account.IncidentId = incident.Id;

            _repositoryWrapper.AccountRepository.Update(account);
            resultIsSuccessFirst = await _repositoryWrapper.SaveChangesAsync() > 0;

            return resultIsSuccessFirst ? Result.Ok(Unit.Value) : Result.Fail(new Error("Failed to create a incident"));
        }

        contact.FirstName = request.Info.ContactFirstName;
        contact.LastName = request.Info.ContactLastName;
        contact.AccountId = account.Id;
        _repositoryWrapper.ContactRepository.Update(contact);

        var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;
        return resultIsSuccess ? Result.Ok(Unit.Value) : Result.Fail(new Error("Failed to update a contact"));
    }
}