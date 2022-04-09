﻿using FluentValidation;
using FluentValidation.Validators;

namespace CRM.Application.Controllers.Accounts.Actions.SignIn
{
    using Api.Requests.Abstractions;

    public class SignInRequest : IRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class SignInRequestValidator : AbstractValidator<SignInRequest>
    {
        public SignInRequestValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}