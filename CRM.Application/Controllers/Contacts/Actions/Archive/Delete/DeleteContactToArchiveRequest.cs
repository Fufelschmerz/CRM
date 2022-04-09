namespace CRM.Application.Controllers.Contacts.Actions.Archive.Delete
{
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class DeleteContactToArchiveRequest :IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteContactToArchiveRequestValidator : AbstractValidator<DeleteContactToArchiveRequest>
    {
        public DeleteContactToArchiveRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}