namespace CRM.Domain.States.Services.Abstractions
{
    using CRM.Domain.States.Enums;
    using CRM.Domain.States.Objects.Entities;
    using global::Domain.Abstracions.Services;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IStateService : IDomainService 
    {
        Task<State> CreateStateAsync(string name, StatusState status, CancellationToken cancellationToken = default);

        Task EditStateAsync(State state, string name, StatusState status, CancellationToken cancellationToken = default);

        Task<IList<State>> GetStateListAsync(CancellationToken cancellationToken = default);

        Task DeleteStateAsync(State state, CancellationToken cancellationToken = default);
    }
}
