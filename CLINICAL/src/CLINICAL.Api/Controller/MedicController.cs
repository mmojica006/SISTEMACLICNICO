using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MedicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListPatients")]
        public async Task<IActionResult> ListExams()
        {
            var response = await _mediator.Send(new GetAllMedicQuery());
            return Ok(response);

        }

    }
}
