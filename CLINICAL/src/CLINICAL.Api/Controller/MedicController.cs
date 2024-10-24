using CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery;
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

        [HttpGet("{medicId:int}")]
        public async Task<IActionResult> ExamById(int medicId)
        {
            var response = await _mediator.Send(new GetMedicByIdQuery() { MedicId= medicId });
            return Ok(response);

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterMedic([FromBody] CreateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        } 

    }
}
