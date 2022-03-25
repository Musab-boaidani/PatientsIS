using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace PatientsIS.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
