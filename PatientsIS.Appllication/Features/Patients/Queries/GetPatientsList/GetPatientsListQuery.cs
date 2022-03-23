using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace PatientsIS.Appllication.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQuery:IRequest<List<GetPatientsListModelView>>
    {

    }
}
