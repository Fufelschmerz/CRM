using Api.Responses.Abstractions;
using CRM.Application.Controllers.Customers.Dto;
using CRM.Application.Infrastructure.Pagination;

namespace CRM.Application.Controllers.Customers.Actions.GetList
{
    public class GetCustomerListResponse : IResponse
    {
        public PaginatedList<CustomerListDto> Customers { get; set; }
    }
}
