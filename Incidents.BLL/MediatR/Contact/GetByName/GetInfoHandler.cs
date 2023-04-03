using AutoMapper;
using FluentResults;
using Incidents.BLL.DTO;
using Incidents.DAL.Repositories.Interfaces.Base;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Incidents.BLL.CustomErrors;

namespace Incidents.BLL.MediatR.Contact.GetByName
{
    public class GetQestionnaireHandler : IRequestHandler<GetInfoQuery, Result<InfoDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GetQestionnaireHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<Result<InfoDTO>> Handle(GetInfoQuery request, CancellationToken cancellationToken)
        {
            var account = await _repositoryWrapper
                .AccountRepository
                .GetFirstOrDefaultAsync(c => c.Name == request.Name, 
                    include: q => q.Include(s => s.Contacts).Include(s => s.Incident));

            if (account is null)
            {
                return Result.Fail(new NotFound($"Cannot find account with name {request.Name}"));
            }

            var infoDto = _mapper.Map<InfoDTO>(account);
            return Result.Ok(infoDto);
        }
    }
}
