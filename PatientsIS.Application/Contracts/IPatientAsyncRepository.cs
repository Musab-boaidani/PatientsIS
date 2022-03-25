using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PatientsIS.Application.Common.Pagination;
using PatientsIS.Domain;

namespace PatientsIS.Application.Contracts
{
    public interface IPatientAsyncRepository:IAsyncRepository<Patient>
    {
        Task UpdatePatientAsync(Patient entity);
        Task<IReadOnlyList<Patient>> ListAllPatientAsync();
    }
}
