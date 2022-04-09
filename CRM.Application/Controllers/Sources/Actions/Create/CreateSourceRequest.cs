namespace CRM.Application.Controllers.Sources.Actions.Create
{
    using FluentValidation;
    using Api.Requests.Abstractions;

    public class CreateSourceRequest : IRequest<CreateSourceResponse>
    {
        public string Name { get; set; }
    }

    public class CreateSourceRequestValidator : AbstractValidator<CreateSourceRequest>
    {
        public CreateSourceRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
