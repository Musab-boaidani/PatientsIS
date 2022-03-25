using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PatientsIS.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQuery:IRequest<List<GetPatientsListModelView>>
    {
        public string? Name { get; set; }
        public int? FileNo { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
