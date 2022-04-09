namespace CRM.Application.Controllers.Contacts.Actions.Archive.Add
{
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class AddContactToArchiveRequest :IRequest
    {
        public long Id { get; set; }
    }

    public class AddContactToArchiveRequestValidator : AbstractValidator<AddContactToArchiveRequest>
    {
        public AddContactToArchiveRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}