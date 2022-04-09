using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using AutoMapper;
using CRM.Application.Infrastructure.Exceptions.Customers;
using CRM.Domain.Common.Queries.Extensions;
using CRM.Domain.ContactPersons.Objects.Entities;
using CRM.Domain.Customers.Objects.Entities;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.ContactPersons.Actions.GetList
{
    public class GetListContactPersonRequestHandler :IAsyncRequestHandler<GetListContactPersonRequest, GetListContactPersonResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IMapper _mapper;

        public GetListContactPersonRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetListContactPersonResponse> ExecuteAsync(GetListContactPersonRequest request, CancellationToken cancellationToken = default)
        {
            var customer = await _queryBuilder.FindByIdAsync<Customer>(request.CustomerId, cancellationToken) ??
                           throw new CustomerNotFoundException();

            var contactPersons = customer.ContactPersons;

            var contactPersonsDto = _mapper.Map<List<ContactPerson>>(contactPersons);

            return new GetListContactPersonResponse {ContactPersons = contactPersonsDto};
        }
    }
}
