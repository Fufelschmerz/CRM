namespace CRM.Application.Controllers.Admins.Actions.Create
{
    using Api.Requests.Abstractions;
    using FluentValidation;
    using FluentValidation.Validators;

    public class CreateFirstAdminRequest : IRequest
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }

    public class CreateFirstAdminRequestValidator : AbstractValidator<CreateFirstAdminRequest>
    {
        public CreateFirstAdminRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .MaximumLength(20);
        }
    }
}
