using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using AutoMapper;
using CRM.Application.Controllers.Users.Dto;
using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries;
using CRM.Application.Infrastructure.Queries.Defaults;
using CRM.Domain.Users.Objects.Entities;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.Users.Actions.GetList
{
    public class GetUserListHandler :IAsyncRequestHandler<GetUserListRequest,  GetUserListResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IMapper _mapper;

        public GetUserListHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetUserListResponse> ExecuteAsync(GetUserListRequest request, CancellationToken cancellationToken = default)
        {
            var userPaginatedList = await _queryBuilder.For<PaginatedList<User>>()
                .WithAsync(new FindPaginationByFilter<GetUserListFilter>(request.Offset, request.Count, request.Filter), cancellationToken);

            var userListDto = _mapper.Map<List<UserListDto>>(userPaginatedList.Items);

            return new GetUserListResponse
            {
                Users = new PaginatedList<UserListDto>(userPaginatedList.TotalCount, userListDto)
            };
        }
    }
}
