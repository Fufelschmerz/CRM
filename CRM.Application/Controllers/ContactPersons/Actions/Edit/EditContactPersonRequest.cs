using FluentValidation;

namespace CRM.Application.Controllers.ContactPersons.Actions.Edit
{
    using System;
    using Api.Requests.Abstractions;
    using CRM.Domain.ContactPersons.Enums;

    public class EditContactPersonRequest : IRequest
    {
        public long Id { get; set; } 

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Post { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string ContactPersonComment { get; set; }
    }

    public class EditContactPersonRequestValidator : AbstractValidator<EditContactPersonRequest>
    {
        public EditContactPersonRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Patronymic).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Post).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Gender).IsInEnum();
            RuleFor(x => x.BirthDate).Must(BeValidDate);
            RuleFor(x => x.ContactPersonComment).MaximumLength(400);
        }

        private bool BeValidDate(DateTime date)
        {
            if (DateTime.Now.Year - date.Year < 18)
                return false;

            return !date.Equals(default(DateTime));
        }
    }
}
