using Api.Requests.Abstractions;
using FluentValidation;

namespace CRM.Application.Controllers.Customers.Actions.Get
{
    public class GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse>
    {
        public long Id { get; set; }
    }

    public class GetCustomerByIdRequestValidator : AbstractValidator<GetCustomerByIdRequest>
    {
        public GetCustomerByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}