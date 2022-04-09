using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries;
using CRM.Application.Infrastructure.Queries.Defaults;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.States.Actions.GetList
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using AutoMapper;
    using Dto;
    using CRM.Domain.States.Objects.Entities;

    public class GetStateListRequestHandler : IAsyncRequestHandler<GetStateListRequest, GetStateListResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IMapper _mapper;

        public GetStateListRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetStateListResponse> ExecuteAsync(GetStateListRequest request, CancellationToken cancellationToken = default)
        {
            var statePaginatedList = await _queryBuilder
                .For<PaginatedList<State>>()
                .WithAsync(new FindPaginationByFilter<GetStateListFilter>(request.Offset, request.Count,
                    request.Filter), cancellationToken);

            var stateListDto = _mapper.Map<List<StateListDto>>(statePaginatedList.Items);

            return new GetStateListResponse
            {
                States = new PaginatedList<StateListDto>(statePaginatedList.TotalCount, stateListDto)
            };
        }
    }
}
