namespace CRM.Application.Controllers.ContactPersons.Actions.Get
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using AutoMapper;
    using Dto;
    using CRM.Application.Infrastructure.Exceptions.ContactPersons;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.ContactPersons.Objects.Entities;
    using Queries.Abstractions.Builders;


    public class GetContactPersonByIdRequestHandler : IAsyncRequestHandler<GetContactPersonByIdRequest, GetContactPersonByIdResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IMapper _mapper;

        public GetContactPersonByIdRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<GetContactPersonByIdResponse> ExecuteAsync(GetContactPersonByIdRequest request, CancellationToken cancellationToken = default)
        {
            var contactPerson = await _queryBuilder.FindByIdAsync<ContactPerson>(request.Id, cancellationToken) ??
                                throw new ContactPersonNotFoundException();

            var contactPersonDto = _mapper.Map<ContactPersonDto>(contactPerson);

            return new GetContactPersonByIdResponse {ContactPerson = contactPersonDto};
        }
    }
}