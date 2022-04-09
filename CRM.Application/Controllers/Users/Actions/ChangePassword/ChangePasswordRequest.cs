using FluentValidation;

namespace CRM.Application.Controllers.Users.Actions.ChangePassword
{
    using Api.Requests.Abstractions;

    public class ChangePasswordRequest : IRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }

    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20);

            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(20);
        }
    }
}
