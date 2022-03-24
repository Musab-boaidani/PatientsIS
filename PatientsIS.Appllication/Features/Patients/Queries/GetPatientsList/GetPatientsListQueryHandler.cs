using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PatientsIS.Application.Contracts;

namespace PatientsIS.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, List<GetPatientsListModelView>>
    {
        public readonly IPatientAsyncRepository _repository;
        public readonly IMapper _mapper;

        public GetPatientsListQueryHandler(IPatientAsyncRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetPatientsListModelView>> Handle(GetPatientsListQuery request, CancellationToken cancellationToken)
        {
            var Patients = await _repository.ListAllAsync();
            var x= _mapper.Map<List<GetPatientsListModelView>>(Patients);
            return x;
        }
    }
}
