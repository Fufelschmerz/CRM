namespace CRM.Application.Controllers.Users.Actions.Create
{
    using FluentValidation;
    using FluentValidation.Validators;
    using Api.Requests.Abstractions;
    using CRM.Domain.Users.Enums;

    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public UserRoles Role { get; set; }
    }

    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Role).IsInEnum();

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .MaximumLength(20);
        }
    }
}
