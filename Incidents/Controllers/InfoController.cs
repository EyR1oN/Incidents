using Incidents.BLL.DTO;
using Incidents.BLL.MediatR.Contact.Create;
using Incidents.BLL.MediatR.Contact.GetByName;
using Incidents.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace Incidents.Controllers
{
    public class InfoController : BaseApiController
    {
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByAccountName(string name)
        {
            return HandleResult(await Mediator.Send(new GetInfoQuery(name)));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InfoDTO info)
        {
            return HandleResult(await Mediator.Send(new CreateContactCommand(info)));
        }
    }
}
