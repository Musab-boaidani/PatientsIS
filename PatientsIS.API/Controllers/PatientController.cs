using PatientsIS.Application.Features.Patients.Commands.CreatePatient;
using PatientsIS.Application.Features.Patients.Commands.UpdatePatient;
using PatientsIS.Application.Features.Patients.Commands.DeletePatient;
using PatientsIS.Application.Features.Patients.Queries.GetPatientsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

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
        public async Task<ActionResult<List<GetPatientsListModelView>>> GetPatientsList(string? Name=null, int? FileNo = null, string? PhoneNumber = null, int Page=1)
        {
            var tuple = await _mediator.Send(new GetPatientsListQuery() { Name = Name, FileNo = FileNo, PhoneNumber = PhoneNumber, Page = Page });
            //Serializing the pager to add to header
            string PagingHeaderText = JsonConvert.SerializeObject(tuple.Item2);

            //adding to header
            Response.Headers.Add("X-Pager", PagingHeaderText);

            //the output list
            var PatientList = tuple.Item1;
            return Ok(PatientList);
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
