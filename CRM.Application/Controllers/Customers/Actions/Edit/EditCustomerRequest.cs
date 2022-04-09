using Api.Requests.Abstractions;
using FluentValidation;

namespace CRM.Application.Controllers.Customers.Actions.Edit
{
    public class EditCustomerRequest : IRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long SourceId { get; set; }

        public long StateId { get; set; }

        public string Description { get; set; }
    }

    public class EditCustomerRequestValidation : AbstractValidator<EditCustomerRequest>
    {
        public EditCustomerRequestValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.SourceId).NotEmpty();
            RuleFor(x => x.StateId).NotEmpty();
        }
    }
}