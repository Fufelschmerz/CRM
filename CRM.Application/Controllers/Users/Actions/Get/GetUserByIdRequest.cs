namespace CRM.Application.Controllers.Users.Actions.Get
{
    using FluentValidation;
    using Api.Requests.Abstractions;

    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public long Id { get; set; }
    }

    public class GetUserByIdRequestValidator : AbstractValidator<GetUserByIdRequest>
    {
        public GetUserByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
