using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PatientsIS.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandValidator:AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(3);
            RuleFor(p => p.FileNo).GreaterThanOrEqualTo(1);
            RuleFor(p => p.CitizenId).NotEmpty();
            RuleFor(p => p.Birthdate).NotEmpty();
            RuleFor(p => p.Gender).IsInEnum();
            RuleFor(p => p.Natinality).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty().MaximumLength(15).MinimumLength(10).Matches(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
            RuleFor(p => p.Email).EmailAddress().NotEmpty();
            RuleFor(p => p.Country).NotEmpty();
            RuleFor(p => p.City).NotEmpty();
            RuleFor(p => p.Street).NotEmpty();
            RuleFor(p => p.Address1).NotEmpty();
            RuleFor(p => p.Address2).NotEmpty();    
            RuleFor(p => p.ContactPerson).NotEmpty();
            RuleFor(p => p.ContactRelation).NotEmpty();
            RuleFor(p => p.ContactPhone).NotEmpty().MaximumLength(15).MinimumLength(10).Matches(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"); ;
            RuleFor(p => p.FirstVisitDate).NotEmpty();
        }
    }
}
