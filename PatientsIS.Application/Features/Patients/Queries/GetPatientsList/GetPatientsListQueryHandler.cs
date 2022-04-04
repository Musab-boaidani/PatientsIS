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
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, Tuple<List<GetPatientsListModelView>, Pager>>
    {
        public readonly IPatientAsyncRepository _repository;
        public readonly IMapper _mapper;

        public GetPatientsListQueryHandler(IPatientAsyncRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Tuple<List<GetPatientsListModelView>,Pager>> Handle(GetPatientsListQuery request, CancellationToken cancellationToken)
        {
            //all the pateint from the DB ,this come from the patient repo
            var Patients = await _repository.ListAllAsync();

            //search pateint
            var SearchPatient = Patients
               .Where(p => (string.IsNullOrEmpty(request.Name) || p.Name.Contains(request.Name.Trim()))
               && (request.FileNo == null || p.FileNo == request.FileNo)
               && (string.IsNullOrEmpty(request.PhoneNumber) || p.PhoneNumber.Contains(request.PhoneNumber.Trim()))).ToList();


            //parameters from pager
            int totalItem = SearchPatient.Count();
     

            //pager
            Pager pager = new Pager(totalItem ,request.Page, request.PageSize); 

            //search and paging to get the needed patients
            var NeededPatient = SearchPatient
                .Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize)
                .ToList();

           
            //mapping the needed patients
            var PatientsListModelView = _mapper.Map<List<GetPatientsListModelView>>(NeededPatient);

            return new Tuple<List<GetPatientsListModelView>, Pager>(PatientsListModelView,pager) ;
        }
    }
}
