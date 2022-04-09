using CRM.Application.Infrastructure.Pagination;
using FluentValidation;

namespace CRM.Application.Controllers.Sources.Actions.GetList
{
    using Api.Requests.Abstractions;

    public class GetSourceListRequest : IRequest<GetSourceListResponse>
    {
        public int Offset { get; set; }

        public int Count { get; set; }

        public GetSourceListFilter Filter { get; set; }
    }

    public class GetSourceListRequestValidator : AbstractValidator<GetSourceListRequest>
    {
        public GetSourceListRequestValidator()
        {
            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Count)
                .GreaterThanOrEqualTo(0);
        }
    }
}
