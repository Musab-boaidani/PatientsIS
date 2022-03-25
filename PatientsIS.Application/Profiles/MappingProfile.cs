using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PatientsIS.Domain;
using PatientsIS.Application.Features.Patients.Commands.CreatePatient;
using PatientsIS.Application.Features.Patients.Commands.UpdatePatient;
using PatientsIS.Application.Features.Patients.Queries.GetPatientsList;
using PatientsIS.Application.Features.Patients.Queries.SearchPatient;

namespace PatientsIS.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
            CreateMap<Patient, GetPatientsListModelView>().ReverseMap();
            CreateMap<Patient, SearchPatientModelView>().ReverseMap();
        }
    }
}
