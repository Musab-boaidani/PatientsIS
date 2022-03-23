using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PatientsIS.Domain;
using PatientsIS.Appllication.Features.Patients.Commands.CreatePatient;
using PatientsIS.Appllication.Features.Patients.Commands.UpdatePatient;

namespace PatientsIS.Appllication.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, CreatePatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
        }
    }
}
