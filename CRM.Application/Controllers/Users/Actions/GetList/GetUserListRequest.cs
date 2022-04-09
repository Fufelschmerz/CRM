namespace CRM.Application.Controllers.Users.Actions.GetList
{
    using Api.Requests.Abstractions;
    using FluentValidation;

    public class GetUserListRequest : IRequest<GetUserListResponse>
    {
        public int Offset { get; set; }

        public int Count { get; set; }

        public GetUserListFilter Filter { get; set; }
    }

    public class GetUserListRequestValidator : AbstractValidator<GetUserListRequest>
    {
        public GetUserListRequestValidator()
        {
            RuleFor(x=>x.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Count)
                .GreaterThanOrEqualTo(0);
        }
    }
}
