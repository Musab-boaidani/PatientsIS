using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PatientsIS.Application.Common.Pagination;

namespace PatientsIS.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQuery:IRequest<Tuple<List<GetPatientsListModelView>, Pager>>
    {
        public int Page { get; set; }
        public string? Name { get; set; }
        public int? FileNo { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
