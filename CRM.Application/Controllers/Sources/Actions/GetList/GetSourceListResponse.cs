using Api.Responses.Abstractions;
using CRM.Application.Controllers.Sources.Dto;
using CRM.Application.Infrastructure.Pagination;

namespace CRM.Application.Controllers.Sources.Actions.GetList
{
    public class GetSourceListResponse : IResponse
    {
        public PaginatedList<SourceListDto> Sources { get; set; }
    }
}
