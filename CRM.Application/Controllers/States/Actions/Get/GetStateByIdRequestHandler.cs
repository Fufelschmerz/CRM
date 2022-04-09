namespace CRM.Application.Controllers.States.Actions.Get
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using AutoMapper;
    using Dto;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.States.Exceptions;
    using CRM.Domain.States.Objects.Entities;
    using Queries.Abstractions.Builders;

    public class GetStateByIdRequestHandler : IAsyncRequestHandler<GetStateByIdRequest, GetStateByIdResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IMapper _mapper;

        public GetStateByIdRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetStateByIdResponse> ExecuteAsync(GetStateByIdRequest request, CancellationToken cancellationToken = default)
        {
            var state = await _queryBuilder.FindByIdAsync<State>(request.Id, cancellationToken) ??
                throw new StateNotFoundException();

            var stateDto = _mapper.Map<State, StateDto>(state);

            return new GetStateByIdResponse() { StateDto = stateDto };
        }
    }
}
