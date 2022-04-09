using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using AutoMapper;
using CRM.Application.Controllers.Customers.Dto;
using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries;
using CRM.Application.Infrastructure.Queries.Defaults;
using CRM.Domain.Customers.Objects.Entities;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.Customers.Actions.GetList
{
    public class GetCustomerListRequestHandler : IAsyncRequestHandler<GetCustomerListRequest, GetCustomerListResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IMapper _mapper;

        public GetCustomerListRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCustomerListResponse> ExecuteAsync(GetCustomerListRequest request, CancellationToken cancellationToken = default)
        {
            var customerPaginatedList = await _queryBuilder.For<PaginatedList<Customer>>()
                .WithAsync(new FindPaginationByFilter<GetCustomerListFilter>(request.Offset, request.Count,
                    request.Filter), cancellationToken);

            var customerListDto = _mapper.Map<List<CustomerListDto>>(customerPaginatedList.Items);

            return new GetCustomerListResponse
            {
                Customers = new PaginatedList<CustomerListDto>(customerPaginatedList.TotalCount, customerListDto)
            };
        }
    }
}
