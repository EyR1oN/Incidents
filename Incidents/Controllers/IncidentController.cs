using Incidents.BLL.DTO;
using Incidents.BLL.MediatR.Incident.Create;
using Incidents.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace Incidents.Controllers
{
    public class IncidentController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IncidentDTO incident)
        {
            return HandleResult(await Mediator.Send(new CreateIncidentCommand(incident)));
        }
    }
}
