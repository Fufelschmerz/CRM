namespace CRM.Application.Controllers.Customers.Actions.Create
{
    using Api.Responses.Abstractions;

    public class CreateCustomerResponse : IResponse
    {
        public long Id { get; set; }
    }
}