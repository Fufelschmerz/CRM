using Api.Responses.Abstractions;
using CRM.Application.Controllers.Contacts.Dto;
using CRM.Application.Infrastructure.Pagination;

namespace CRM.Application.Controllers.Contacts.Actions.GetList
{
    public class GetContactListForManagerResponse : IResponse
    {
        public PaginatedList<ContactListDto> Contacts { get; set; }
    }
}
