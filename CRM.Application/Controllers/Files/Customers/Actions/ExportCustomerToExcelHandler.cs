using System.IO;
using CRM.Application.Infrastructure.Files.Excel.Services.Abstractions;

namespace CRM.Application.Controllers.Files.Customers.Actions
{
    using System;
    using System.Collections.Generic;
    using Dto;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Customers.Objects.Entities;
    using Api.Requests.Handlers;
    using AutoMapper;
    using Queries.Abstractions.Builders;
    using System.Threading;
    using System.Threading.Tasks;

    public class ExportCustomerToExcelHandler :IAsyncRequestHandler<ExportCustomerToExcelRequest>
    {
        private readonly IExcelService _excelService;
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IMapper _mapper;

        public ExportCustomerToExcelHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper, IExcelService excelService)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));

            _excelService = excelService ??
                            throw new ArgumentNullException(nameof(excelService));
        }

        public async Task ExecuteAsync(ExportCustomerToExcelRequest request, CancellationToken cancellationToken = default)
        {
            var customers = await _queryBuilder.FindAllAsync<Customer>(cancellationToken);

            var customersDto = _mapper.Map<List<CustomerDto>>(customers);

            var file = _excelService.ExportData(request.Headers, customersDto, request.TableName);

            await File.WriteAllBytesAsync($"{request.TableName}.xlsx", file, cancellationToken);
        }
    }
}
