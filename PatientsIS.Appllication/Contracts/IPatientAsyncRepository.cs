using System;
using System.Collections.Generic;
using System.Text;
using PatientsIS.Domain;

namespace PatientsIS.Appllication.Contracts
{
    public interface IPatientAsyncRepository:IAsyncRepository<Patient>
    {
    }
}
