using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PatientsIS.Application.Common.Pagination;

namespace PatientsIS.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientQuery:IRequest<GetPatientModelView>
    {
        public Guid Id { get; set; }
    }
}
