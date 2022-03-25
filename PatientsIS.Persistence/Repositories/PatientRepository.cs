
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PatientsIS.Application.Contracts;
using PatientsIS.Domain;
using PatientsIS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentIS.Persistence
{
    public class PatientRepository : BaseRepository<Patient>, IPatientAsyncRepository
    {
        public PatientRepository(PatientsDbContext postDbContext): base(postDbContext)
        {

        }
        
        public  async Task UpdatePatientAsync(Patient patient)
        {
           
            _dbContext.Entry(patient).State = EntityState.Modified;
            _dbContext.Entry(patient).Property(p => p.RecordCreationDate).IsModified = false;

            await _dbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<Patient>> ListAllPatientAsync(string? Name, int? FileNo, string? PhoneNumber)
            {
           
                return await _dbContext.Patients.Where(p => (Name == null || p.Name.Contains(Name)) && (FileNo == null || p.FileNo == FileNo) && (PhoneNumber==null || p.PhoneNumber.Contains(PhoneNumber) )).ToListAsync();
                
            }
        }

}
