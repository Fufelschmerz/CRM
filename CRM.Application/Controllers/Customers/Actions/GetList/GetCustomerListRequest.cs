using Api.Requests.Abstractions;
using FluentValidation;

namespace CRM.Application.Controllers.Customers.Actions.GetList
{
    public class GetCustomerListRequest : IRequest<GetCustomerListResponse>
    {
        public int Offset { get; set; }

        public int Count { get; set; }

        public GetCustomerListFilter Filter { get; set; }
    }

    public class GetCustomerListRequestValidator : AbstractValidator<GetCustomerListRequest>
    {
        public GetCustomerListRequestValidator()
        {
            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Count)
                .GreaterThanOrEqualTo(0);
        }
    }
}
