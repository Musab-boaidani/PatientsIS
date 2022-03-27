using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PatientsIS.Application.Common.Pagination;
using PatientsIS.Application.Contracts;

namespace PatientsIS.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, GetPatientModelView>
    {
        public readonly IPatientAsyncRepository _repository;
        public readonly IMapper _mapper;

        public GetPatientQueryHandler(IPatientAsyncRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetPatientModelView> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var Patient = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetPatientModelView>(Patient);
        }
    }
}
