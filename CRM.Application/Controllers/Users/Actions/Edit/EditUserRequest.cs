namespace CRM.Application.Controllers.Users.Actions.Edit
{
    using FluentValidation;
    using Api.Requests.Abstractions;
    using CRM.Domain.Users.Enums;
    using FluentValidation.Validators;

    public class EditUserRequest : IRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public UserRoles UserRole { get; set; }
    }

    public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
    {
        public EditUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.UserRole)
                .IsInEnum();
        }
    }
}
