using Api.Responses.Abstractions;
using CRM.Application.Controllers.States.Dto;
using CRM.Application.Infrastructure.Pagination;

namespace CRM.Application.Controllers.States.Actions.GetList
{
    public class GetStateListResponse : IResponse
    {
        public PaginatedList<StateListDto> States { get; set; }
    }
}
