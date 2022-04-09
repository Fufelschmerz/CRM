namespace CRM.Application.Controllers.States.Actions.Archive.Add
{
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class AddStateToArchiveRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class AddStateToArchiveRequestValidator : AbstractValidator<AddStateToArchiveRequest>
    {
        public AddStateToArchiveRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
