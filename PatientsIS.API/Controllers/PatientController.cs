using PatientsIS.Application.Features.Patients.Commands.CreatePatient;
using PatientsIS.Application.Features.Patients.Commands.UpdatePatient;
using PatientsIS.Application.Features.Patients.Commands.DeletePatient;
using PatientsIS.Application.Features.Patients.Queries.GetPatientsList;
using PatientsIS.Application.Features.Patients.Queries.SearchPatient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PatientsIS.API.Controllers
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

        [HttpGet("~/api/Patients", Name = "GetPatientsList")]
        public async Task<ActionResult<List<GetPatientsListModelView>>> GetPatientsList()
        {
            var PL = await _mediator.Send(new GetPatientsListQuery());
            return Ok(PL);
        }
        [HttpGet("Search", Name = "SearchForPatient")]
        public async Task<ActionResult<List<SearchPatientModelView>>> SearchForPatient(string? Name=null, int? FileNo = null, string? PhoneNumber = null)
        {
            var PL = await _mediator.Send(new SearchPatientQuery() { Name=Name,FileNo=FileNo,PhoneNumber=PhoneNumber});
            return Ok(PL);
        }
        [HttpPost(Name = "AddPatient")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePatientCommand createPatientCommand)
        {
            Guid id = await _mediator.Send(createPatientCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdatePatient")]
        public async Task<ActionResult> Update([FromBody] UpdatePatientCommand updatePatientCommand )
        {
            await _mediator.Send(updatePatientCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePatient")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePatientCommand = new DeletePatientCommand() { Id = id };
            await _mediator.Send(deletePatientCommand);
            return NoContent();
        }
    }
}
