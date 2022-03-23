using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace PatientsIS.Appllication.Features.Patients.Commands.DeletePatient
{
    internal class DeletePatientCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
