using FluentValidation;

namespace CRM.Application.Controllers.States.Actions.GetList
{
    using Api.Requests.Abstractions;

    public class GetStateListRequest: IRequest<GetStateListResponse>
    {
        public int Offset { get; set; }

        public int Count { get; set; }

        public GetStateListFilter Filter { get; set; }
    }

    public class GetStateListRequestValidator : AbstractValidator<GetStateListRequest>
    {
        public GetStateListRequestValidator()
        {
            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Count)
                .GreaterThanOrEqualTo(0);
        }
    }
}
