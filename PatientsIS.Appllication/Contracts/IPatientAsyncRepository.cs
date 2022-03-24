using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PatientsIS.Domain;

namespace PatientsIS.Application.Contracts
{
    public interface IPatientAsyncRepository:IAsyncRepository<Patient>
    {
        Task<IReadOnlyList<Patient>> SearchAsync(string? Name,int? FileNo, string? PhoneNumber );
    }
}
