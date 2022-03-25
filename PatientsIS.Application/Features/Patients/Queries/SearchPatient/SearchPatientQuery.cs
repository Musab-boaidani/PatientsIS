using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PatientsIS.Application.Features.Patients.Queries.SearchPatient
{
    public class SearchPatientQuery:IRequest<List<SearchPatientModelView>>
    {
        public string? Name { get; set; }
        public int? FileNo { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
