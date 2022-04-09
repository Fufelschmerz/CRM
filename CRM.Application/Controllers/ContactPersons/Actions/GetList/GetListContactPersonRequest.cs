using Api.Requests.Abstractions;
using FluentValidation;

namespace CRM.Application.Controllers.ContactPersons.Actions.GetList
{
    public class GetListContactPersonRequest : IRequest<GetListContactPersonResponse>
    {
        public long CustomerId { get; set; }
    }

    public class GetListContactPersonRequestValidator : AbstractValidator<GetListContactPersonRequest>
    {
        public GetListContactPersonRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
}
