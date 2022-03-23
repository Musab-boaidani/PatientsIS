using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using PatientsIS.Appllication.Contracts;
using PatientsIS.Domain;

namespace PatientsIS.Appllication.Features.Patients.Commands.CreatePatient
{
    internal class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        public readonly IMapper _mapper;
        public readonly IPatientAsyncRepository _repository;

        public CreatePatientCommandHandler(IMapper mapper, IPatientAsyncRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient=_mapper.Map<Patient>(request);
            patient= await _repository.AddAsync(patient);
            return patient.Id;
        }
    }
}
