using Api.Requests.Abstractions;
using FluentValidation;

namespace CRM.Application.Controllers.ContactPersons.Actions.Delete
{
    public class DeleteContactPersonRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteContactPersonRequestValidator : AbstractValidator<DeleteContactPersonRequest>
    {
        public DeleteContactPersonRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}