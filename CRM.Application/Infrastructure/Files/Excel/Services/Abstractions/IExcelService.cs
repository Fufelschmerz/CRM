namespace CRM.Application.Infrastructure.Files.Excel.Services.Abstractions
{
    using CRM.Application.Controllers.Files.Customers.Dto;
    using global::Application.Services;
    using System.Collections.Generic;

    public interface IExcelService : IApplicationService
    {
        //byte[] ExportCustomers(IEnumerable<string> header, IEnumerable<CustomerDto> data, string tableName);

        byte[] ExportData<T>(IEnumerable<string> header, IEnumerable<T> data, string tableName);
    }
}