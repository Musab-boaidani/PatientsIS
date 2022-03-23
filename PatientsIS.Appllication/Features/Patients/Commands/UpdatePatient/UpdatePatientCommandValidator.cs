using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PatientsIS.Appllication.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandValidator:AbstractValidator<UpdatePatientCommand>
    {
        UpdatePatientCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(3);
            RuleFor(p => p.FileNo).NotEmpty();
            RuleFor(p => p.CitizenId).NotEmpty();
            RuleFor(p => p.Birthdate).NotEmpty();
            RuleFor(p => p.Gender).NotEmpty();
            RuleFor(p => p.Natinality).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty();
            RuleFor(p => p.Email).EmailAddress().NotEmpty();
            RuleFor(p => p.Country).NotEmpty();
            RuleFor(p => p.City).NotEmpty();
            RuleFor(p => p.Street).NotEmpty();
            RuleFor(p => p.Address1).NotEmpty();
            RuleFor(p => p.Address2).NotEmpty();
            RuleFor(p => p.ContactPerson).NotEmpty();
            RuleFor(p => p.ContactRelation).NotEmpty();
            RuleFor(p => p.ContactPhone).NotEmpty();
            RuleFor(p => p.ContactPhone).NotEmpty();
        }
    }
}
