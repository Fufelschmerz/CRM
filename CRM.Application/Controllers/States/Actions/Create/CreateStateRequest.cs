using Api.Requests.Abstractions;
using CRM.Domain.States.Enums;
using FluentValidation;

namespace CRM.Application.Controllers.States.Actions.Create
{
    public class CreateStateRequest : IRequest<CreateStateResponse>
    {
        public string Name { get; set; }

        public StatusState Status { get; set; }
    }

    public class CreateStateRequestValidator : AbstractValidator<CreateStateRequest>
    {
        public CreateStateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
