namespace CRM.Application.Controllers.ContactPersons.Actions.Contacts.Add
{
    using Api.Requests.Abstractions;
    using CRM.Domain.ContactPersons.Enums;
    using FluentValidation;

    public class AddContactDataRequest : IRequest
    {
        public long ContactPersonId { get; set; }
        
        public string Value { get; set; }

        public string Comment { get; set; }

        public ContactDataType ContactDataType { get; set; }
    }

    public class AddContactRequestValidator : AbstractValidator<AddContactDataRequest>
    {
        public AddContactRequestValidator()
        {
            RuleFor(x => x.ContactPersonId).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.Comment).MaximumLength(100);
            RuleFor(x => x.ContactDataType).IsInEnum();
        }
    }
}