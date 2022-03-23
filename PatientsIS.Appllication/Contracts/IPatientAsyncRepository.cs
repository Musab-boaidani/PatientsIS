using System;
using System.Collections.Generic;
using System.Text;
using PatientsIS.Domain;

namespace PatientsIS.Appllication.Contracts
{
    internal interface IPatientAsyncRepository:IAsyncRepository<Patient>
    {
    }
}
