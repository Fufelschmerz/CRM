namespace CRM.Application.Controllers.Files.Customers.Actions
{
    using Api.Requests.Abstractions;

    public class ExportCustomerToExcelRequest : IRequest
    {
        public string [] Headers { get; set; }

        public string TableName { get; set; }
    }
}
