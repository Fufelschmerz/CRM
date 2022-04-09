using Api.Requests.Abstractions;
using CRM.Domain.States.Enums;
using FluentValidation;

namespace CRM.Application.Controllers.States.Actions.Edit
{
    public class EditStateRequest : IRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public StatusState Status { get; set; }

    }

    public class EditStateRequestValidator : AbstractValidator<EditStateRequest>
    {
        public EditStateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
