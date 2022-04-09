using CRM.Domain.States.Criteria;

namespace CRM.Domain.States.Services
{
    using Commands.Absctractions.Builders;
    using CRM.Domain.Common.Commands.Extensions;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.States.Enums;
    using CRM.Domain.States.Exceptions;
    using CRM.Domain.States.Objects.Entities;
    using CRM.Domain.States.Services.Abstractions;
    using Queries.Abstractions.Builders;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class StateService : IStateService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IAsyncCommandBuilder _commandBuilder;

        public StateService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));

            _commandBuilder = commandBuilder ??
                throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task<State> CreateStateAsync(string name, StatusState status, CancellationToken cancellationToken = default)
        {
            await CheckStateByNameAsync(name, status, cancellationToken);

            var state = new State(name, status);

            await _commandBuilder.CreateAsync(state, cancellationToken);

            return state;
        }

        public async Task<IList<State>> GetStateListAsync(CancellationToken cancellationToken = default)
        {
            return await _queryBuilder.FindAllAsync<State>(cancellationToken);
        }

        public async Task DeleteStateAsync(State state, CancellationToken cancellationToken = default)
        {
            await _commandBuilder.DeleteAsync(state, cancellationToken);
        }

        public async Task EditStateAsync(State state, string name, StatusState status, CancellationToken cancellationToken = default)
        { 
            await CheckStateByNameAsync(name, status, cancellationToken);
            
            state.CreateOrEditState(name, status);
        }

        private async Task CheckStateByNameAsync(string name, StatusState status, CancellationToken cancellationToken = default)
        {
            var state = await _queryBuilder.For<State>()
                .WithAsync(new FindStateByNameAndType(name, status), cancellationToken);

            if (state != null)
                throw new StateAlreadyExistsException();
        }
    }
}
