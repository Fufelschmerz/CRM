namespace CRM.Application.Controllers.Users.Actions.Delete
{
    using FluentValidation;
    using Api.Requests.Abstractions;

    public class DeleteUserRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
