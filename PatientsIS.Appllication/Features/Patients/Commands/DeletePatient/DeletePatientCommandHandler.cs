using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PatientsIS.Domain;
using AutoMapper;
using PatientsIS.Appllication.Contracts;

namespace PatientsIS.Appllication.Features.Patients.Commands.DeletePatient
{

    internal class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
      
        public readonly IPatientAsyncRepository _repository;

        public DeletePatientCommandHandler( IPatientAsyncRepository repository)
        {
      
            _repository = repository;
        }
        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(patient);
            return Unit.Value;

        }
    }
}
