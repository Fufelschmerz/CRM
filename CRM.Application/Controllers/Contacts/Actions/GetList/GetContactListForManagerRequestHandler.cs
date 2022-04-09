using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using AutoMapper;
using CRM.Application.Controllers.Contacts.Dto;
using CRM.Application.Infrastructure.Authorization.Providers;
using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries.Entities.Contacts;
using CRM.Domain.Contacts.Objects.Entities;
using CRM.Domain.Users.Objects.Entities;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.Contacts.Actions.GetList
{
    public class GetContactListForManagerRequestHandler : IAsyncRequestHandler<GetContactListForManagerRequest, GetContactListForManagerResponse>
    {
        private readonly IAsyncUserProvider<User> _userProvider;

        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IMapper _mapper;

        public GetContactListForManagerRequestHandler(IAsyncUserProvider<User> userProvider, IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _userProvider = userProvider ??
                            throw new ArgumentNullException(nameof(userProvider));

            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetContactListForManagerResponse> ExecuteAsync(GetContactListForManagerRequest forManagerRequest, CancellationToken cancellationToken = default)
        {
            var manager = await _userProvider.GetUserAsync(cancellationToken);

            var contactPaginatedList = await _queryBuilder.For<PaginatedList<Contact>>()
                    .WithAsync(new FindPaginationContactsByManagerId(forManagerRequest.Offset, forManagerRequest.Count, manager.Id), cancellationToken);

            var contactListDto = _mapper.Map<List<ContactListDto>>(contactPaginatedList.Items);

            return new GetContactListForManagerResponse
            {
                Contacts = new PaginatedList<ContactListDto>(contactPaginatedList.TotalCount, contactListDto)
            };
        }
    }
}
