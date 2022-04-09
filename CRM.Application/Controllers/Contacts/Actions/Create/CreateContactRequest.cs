using CRM.Domain.Contacts.Enums;

namespace CRM.Application.Controllers.Contacts.Actions.Create
{
    using System;
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class CreateContactRequest :IRequest<CreateContactResponse>
    {
        public long CustomerId { get; set; }

        public long ContactPersonId { get; set; }

        public long ContactDataId { get; set; }

        public string Comment { get; set; }

        public long ManagerId { get; set; }

        public DateTime EventOfDate { get; set; }

        public StateContact State { get; set; }

        public DateTime PlannedEventOfDate { get; set; }
    }

    public class CreateContactRequestValidator : AbstractValidator<CreateContactRequest>
    {
        public CreateContactRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.ContactPersonId).NotEmpty();
            RuleFor(x => x.ContactDataId).NotEmpty();
            RuleFor(x => x.Comment).MaximumLength(4000);
            RuleFor(x => x.ManagerId).NotEmpty();
            RuleFor(x => x.EventOfDate).NotEmpty();
            RuleFor(x => x.State).NotEmpty().IsInEnum();
            RuleFor(x => x.PlannedEventOfDate).NotEmpty();
        }
    }
}