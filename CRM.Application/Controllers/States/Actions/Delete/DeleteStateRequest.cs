using Api.Requests.Abstractions;
using FluentValidation;

namespace CRM.Application.Controllers.States.Actions.Delete
{
    public class DeleteStateRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteStateRequestValidator : AbstractValidator<DeleteStateRequest>
    {
        public DeleteStateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
