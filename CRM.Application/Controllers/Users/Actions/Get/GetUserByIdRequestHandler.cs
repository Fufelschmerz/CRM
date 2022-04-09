namespace CRM.Application.Controllers.Users.Actions.Get
{
    using Api.Requests.Handlers;
    using AutoMapper;
    using CRM.Application.Controllers.Users.Dto;
    using CRM.Application.Infrastructure.Exceptions.Users;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Users.Objects.Entities;
    using Queries.Abstractions.Builders;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserByIdRequestHandler : IAsyncRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IAsyncQueryBuilder _queryBilder;

        private readonly IMapper _mapper;

        public GetUserByIdRequestHandler(IAsyncQueryBuilder queryBuilder, IMapper mapper)
        {
            _queryBilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetUserByIdResponse> ExecuteAsync(GetUserByIdRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _queryBilder.FindByIdAsync<User>(request.Id, cancellationToken) ??
                throw new UserNotFoundException();

            var userDto = _mapper.Map<User, UserDto>(user);

            return new GetUserByIdResponse { User = userDto };
        }
    }
}
