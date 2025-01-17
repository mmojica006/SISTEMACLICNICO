﻿using CLINICAL.Application.UseCase.UseCases.Exam.Commands.ChangestateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListPatient")]
        public async Task<ActionResult> ListPatient()
        {
            var response = await _mediator.Send(new GetAllPatientQuery());
            return Ok(response);
        }

        [HttpGet("{patientId:int}")]
        public async Task<ActionResult> PatientById(int patientId)
        {
            var response = await _mediator.Send(new GetPatientByIdQuery() { PatientId = patientId });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterExam([FromBody] CreatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditExam([FromBody] UpdatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Remove/{patientId:int}")]
        public async Task<IActionResult> DeletePatient(int patientId)
        {
            var response = await _mediator.Send(new DeletePatientCommand() { PatientId = patientId });
            return Ok(response);
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStatePatient([FromBody] ChangeStatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
