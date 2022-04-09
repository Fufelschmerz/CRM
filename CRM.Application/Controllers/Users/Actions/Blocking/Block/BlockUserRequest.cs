namespace CRM.Application.Controllers.Users.Actions.Blocking.Block
{
    using FluentValidation;
    using Api.Requests.Abstractions;
    
    public class BlockUserRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class BlockUserRequestValidator : AbstractValidator<BlockUserRequest>
    {
        public BlockUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
