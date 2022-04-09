using FluentValidation;

namespace CRM.Application.Controllers.Users.Actions.Blocking.Unlock
{
    using Api.Requests.Abstractions;

    public class UnlockUserRequest :IRequest 
    {
        public long Id { get; set; }
    }

    public class UnlockUserRequestValidator : AbstractValidator<UnlockUserRequest>
    {
        public UnlockUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
