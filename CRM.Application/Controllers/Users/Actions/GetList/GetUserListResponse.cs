using Api.Responses.Abstractions;
using CRM.Application.Controllers.Users.Dto;
using CRM.Application.Infrastructure.Pagination;

namespace CRM.Application.Controllers.Users.Actions.GetList
{
    public class GetUserListResponse : IResponse
    {
        public PaginatedList<UserListDto> Users { get; set; }
    }
}
