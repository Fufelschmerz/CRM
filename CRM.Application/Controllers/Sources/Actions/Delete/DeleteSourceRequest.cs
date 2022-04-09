namespace CRM.Application.Controllers.Sources.Actions.Delete
{
    using FluentValidation;
    using Api.Requests.Abstractions;

    public class DeleteSourceRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteSourceRequestValidator : AbstractValidator<DeleteSourceRequest>
    {
        public DeleteSourceRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
