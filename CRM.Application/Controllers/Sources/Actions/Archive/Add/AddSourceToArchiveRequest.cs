using Api.Requests.Abstractions;
using FluentValidation;

namespace CRM.Application.Controllers.Sources.Actions.Archive.Add
{
    public class AddSourceToArchiveRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class AddSourceToArchiveRequestValidator : AbstractValidator<AddSourceToArchiveRequest>
    {
        public AddSourceToArchiveRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
