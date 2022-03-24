using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PatientsIS.Application.Contracts;

namespace PatientsIS.Application.Features.Patients.Queries.SearchPatient
{
    public class SearchPatientQueryHandler : IRequestHandler<SearchPatientQuery, List<SearchPatientModelView>>
    {
        public readonly IPatientAsyncRepository _repository;
        public readonly IMapper _mapper;

        public SearchPatientQueryHandler(IPatientAsyncRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SearchPatientModelView>> Handle(SearchPatientQuery request, CancellationToken cancellationToken)
        {
            var Patients = await _repository.SearchAsync(request.Name,request.FileNo,request.PhoneNumber);
            var x= _mapper.Map<List<SearchPatientModelView>>(Patients);
            return x;
        }
    }
}
