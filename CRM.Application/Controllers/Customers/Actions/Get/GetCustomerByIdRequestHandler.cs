using System;
using Api.Requests.Handlers;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Controllers.Customers.Dto;
using CRM.Application.Infrastructure.Exceptions.Customers;
using CRM.Domain.Common.Queries.Extensions;
using CRM.Domain.Customers.Objects.Entities;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.Customers.Actions.Get
{
    public class GetCustomerByIdRequestHandler : IAsyncRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IMapper _mapper;

        public GetCustomerByIdRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCustomerByIdResponse> ExecuteAsync(GetCustomerByIdRequest request, CancellationToken cancellationToken = default)
        {
            var customer = await _queryBuilder.FindByIdAsync<Customer>(request.Id, cancellationToken) ??
                           throw new CustomerNotFoundException();

            var customerDto = _mapper.Map<Customer, CustomerDto>(customer);

            return new GetCustomerByIdResponse {Customer = customerDto};
        }
    }
}