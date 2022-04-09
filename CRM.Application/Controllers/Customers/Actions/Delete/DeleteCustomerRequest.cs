using Api.Requests.Abstractions;
using FluentValidation;

namespace CRM.Application.Controllers.Customers.Actions.Delete
{
    public class DeleteCustomerRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}