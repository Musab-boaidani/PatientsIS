using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PatientsIS.Domain;
using PatientsIS.Appllication.Features.Patients.Commands.CreatePatient;
using PatientsIS.Appllication.Features.Patients.Commands.UpdatePatient;
using PatientsIS.Appllication.Features.Patients.Queries.GetPatientsList;

namespace PatientsIS.Appllication.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
            CreateMap<Patient, GetPatientsListModelView>().ReverseMap();
        }
    }
}
