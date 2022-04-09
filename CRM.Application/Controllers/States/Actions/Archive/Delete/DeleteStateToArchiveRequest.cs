namespace CRM.Application.Controllers.States.Actions.Archive.Delete
{
    using FluentValidation;
    using Api.Requests.Abstractions;

    public class DeleteStateToArchiveRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteStateToArchiveRequestValidator : AbstractValidator<DeleteStateToArchiveRequest>
    {
        public DeleteStateToArchiveRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}