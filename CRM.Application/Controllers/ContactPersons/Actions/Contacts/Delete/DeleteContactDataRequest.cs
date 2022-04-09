namespace CRM.Application.Controllers.ContactPersons.Actions.Contacts.Delete
{
    using FluentValidation;
    using Api.Requests.Abstractions;

    public class DeleteContactDataRequest :IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteContactDataValidator : AbstractValidator<DeleteContactDataRequest>
    {
        public DeleteContactDataValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}