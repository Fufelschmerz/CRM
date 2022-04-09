using CRM.Application.Controllers.Customers.Dto;

namespace CRM.Application.Controllers.Customers.Actions.Get
{
    using Api.Responses.Abstractions;

    public class GetCustomerByIdResponse : IResponse
    {
        public CustomerDto Customer { get; set; }
    }
}