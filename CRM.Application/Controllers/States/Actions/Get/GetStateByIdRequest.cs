using Api.Requests.Abstractions;
using FluentValidation;

namespace CRM.Application.Controllers.States.Actions.Get
{
    public class GetStateByIdRequest : IRequest<GetStateByIdResponse>
    {
        public long Id { get; set; }
    }

    public class GetStateByIdRequestValidator : AbstractValidator<GetStateByIdRequest>
    {
        public GetStateByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
