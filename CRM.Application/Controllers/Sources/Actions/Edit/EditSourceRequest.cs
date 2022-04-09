namespace CRM.Application.Controllers.Sources.Actions.Edit
{
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class EditSourceRequest : IRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class EditSourceRequestValidator : AbstractValidator<EditSourceRequest>
    {
        public EditSourceRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
