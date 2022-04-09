namespace CRM.Application.Controllers.Sources.Actions.Archive.Delete
{
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class DeleteSourceToArchiveRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteSourceToArchiveRequestValidator : AbstractValidator<DeleteSourceToArchiveRequest>
    {
        public DeleteSourceToArchiveRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}