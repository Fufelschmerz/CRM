namespace CRM.Application.Controllers.ContactPersons.Actions.Create
{
    using System;
    using Api.Requests.Abstractions;
    using CRM.Domain.ContactPersons.Enums;
    using FluentValidation;

    public class CreateContactPersonRequest : IRequest<CreateContactPersonResponse>
    {
        public long CustomerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Post { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string ContactPersonComment { get; set; }

        public string ContactValue { get; set; }

        public string ContactComment { get; set; }


        public ContactDataType ContactDataType { get; set; }
    }

    public class CreateContactPersonRequestValidator : AbstractValidator<CreateContactPersonRequest>
    {
        public CreateContactPersonRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Patronymic).NotEmpty().MaximumLength(60);
            RuleFor(x => x.Post).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Gender).IsInEnum();
            RuleFor(x => x.BirthDate).Must(BeValidDate);
            RuleFor(x => x.ContactValue).NotEmpty();
            RuleFor(x => x.ContactPersonComment).MaximumLength(400);
            RuleFor(x => x.ContactComment).MaximumLength(100);
            RuleFor(x => x.ContactDataType).IsInEnum();
        }

        private bool BeValidDate(DateTime date)
        {
            if (DateTime.Now.Year - date.Year < 18)
                return false;

            return !date.Equals(default(DateTime));
        }
    }
}
