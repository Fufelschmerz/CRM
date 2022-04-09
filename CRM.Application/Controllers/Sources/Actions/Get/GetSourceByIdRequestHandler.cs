namespace CRM.Application.Controllers.Sources.Actions.Get
{
    using Dto;
    using Api.Requests.Handlers;
    using AutoMapper;
    using CRM.Application.Infrastructure.Exceptions.Sources;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Sources.Objects.Entities;
    using Queries.Abstractions.Builders;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetSourceByIdRequestHandler : IAsyncRequestHandler<GetSourceByIdRequest, GetSourceByIdResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IMapper _mapper; 

        public GetSourceByIdRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetSourceByIdResponse> ExecuteAsync(GetSourceByIdRequest request, CancellationToken cancellationToken = default)
        {
            var source = await _queryBuilder.FindByIdAsync<Source>(request.Id, cancellationToken) ??
                throw new SourceNotFoundException();

            var sourceDto = _mapper.Map<Source, SourceDto>(source);

            return new GetSourceByIdResponse { Source = sourceDto };
        }
    }
}
