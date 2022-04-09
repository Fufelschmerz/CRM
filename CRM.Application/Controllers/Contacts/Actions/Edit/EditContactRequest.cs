using CRM.Domain.Contacts.Enums;

namespace CRM.Application.Controllers.Contacts.Actions.Edit
{
    using System;
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class EditContactRequest : IRequest
    {
        public long Id { get; set; }

        public long ContactPersonId { get; set; }

        public long ContactDataId { get; set; }

        public string Comment { get; set; }

        public long ManagerId { get; set; }

        public DateTime EventOfDate { get; set; }

        public StateContact State { get; set; }

        public DateTime PlannedEventOfDate { get; set; }
    }
    
    public class EditContactRequestValidation : AbstractValidator<EditContactRequest>
    {
        public EditContactRequestValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
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