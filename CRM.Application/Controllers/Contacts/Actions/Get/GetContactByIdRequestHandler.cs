namespace CRM.Application.Controllers.Contacts.Actions.Get
{
    using System;
    using Api.Requests.Handlers;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Dto;
    using CRM.Application.Infrastructure.Exceptions.Contacts;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Contacts.Objects.Entities;
    using Queries.Abstractions.Builders;

    public class GetContactByIdRequestHandler : IAsyncRequestHandler<GetContactByIdRequest, GetContactByIdResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IMapper _mapper;

        public GetContactByIdRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetContactByIdResponse> ExecuteAsync(GetContactByIdRequest request, CancellationToken cancellationToken = default)
        {
            var contact = await _queryBuilder.FindByIdAsync<Contact>(request.Id, cancellationToken) ??
                          throw new ContactNotFoundException();

            var contactDto = _mapper.Map<ContactDto>(contact);

            return new GetContactByIdResponse {Contact = contactDto};
        }
    }
}