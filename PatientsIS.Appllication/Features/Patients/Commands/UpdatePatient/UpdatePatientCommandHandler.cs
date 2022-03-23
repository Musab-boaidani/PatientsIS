using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PatientsIS.Appllication.Contracts;
using AutoMapper;
using PatientsIS.Domain;

namespace PatientsIS.Appllication.Features.Patients.Commands.UpdatePatient
{
    internal class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        public readonly IPatientAsyncRepository _repository;
        public readonly IMapper _mapper;

        public UpdatePatientCommandHandler(IPatientAsyncRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = _mapper.Map<Patient>(request);
            await _repository.UpdateAsync(patient);
            return Unit.Value;
        }
    }
}
