namespace CRM.Application.Controllers.Customers.Actions.Create
{
    using FluentValidation;
    using Api.Requests.Abstractions;

    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string Name { get; set; }

        public long SourceId { get; set; }

        public long StateId { get; set; }

        public string Description { get; set; }
    }

    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.SourceId).NotEmpty();
            RuleFor(x => x.StateId).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(400);
        }
    }
}