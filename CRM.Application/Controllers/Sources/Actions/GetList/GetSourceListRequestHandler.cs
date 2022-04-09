using CRM.Application.Infrastructure.Pagination;
using CRM.Application.Infrastructure.Queries;
using CRM.Application.Infrastructure.Queries.Defaults;
using CRM.Domain.Common.Queries.Extensions;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.Sources.Actions.GetList
{
    using Api.Requests.Handlers;
    using AutoMapper;
    using Dto;
    using CRM.Domain.Sources.Objects.Entities;
    using CRM.Domain.Sources.Services.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    public class GetSourceListRequestHandler : IAsyncRequestHandler<GetSourceListRequest, GetSourceListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncQueryBuilder _queryBuilder;

        public GetSourceListRequestHandler(IMapper mapper, IAsyncQueryBuilder queryBuilder)
        {
            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));

            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task<GetSourceListResponse> ExecuteAsync(GetSourceListRequest request, CancellationToken cancellationToken = default)
        {
            var sourcePaginatedList = await _queryBuilder
                .For<PaginatedList<Source>>()
                .WithAsync(new FindPaginationByFilter<GetSourceListFilter>(request.Offset, request.Count,
                        request.Filter), cancellationToken);

            var sourceListDto = _mapper.Map<List<SourceListDto>>(sourcePaginatedList.Items);

            return new GetSourceListResponse {Sources  = new PaginatedList<SourceListDto>(sourcePaginatedList.TotalCount, sourceListDto)};
        }
    }
}
