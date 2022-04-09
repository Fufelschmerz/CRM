using System;
using System.Threading;
using System.Threading.Tasks;
using Commands.Absctractions.Commands;
using Commands.Absctractions.Cotexts;
using Domain.Abstracions.Identification;
using Repositories.Abstractions;

namespace CRM.Persistence.ORM.Common.Repositories
{
    public abstract class RepositoryAsyncCommandBase<T, TCommandContext> : IAsyncCommand<TCommandContext>
        where T: class, IHasId, new()
        where TCommandContext: ICommandContext
    {
        protected RepositoryAsyncCommandBase(IAsyncRepository<T> repository)
        {
            Repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        protected IAsyncRepository<T> Repository { get; }

        public abstract Task ExecuteAsync(TCommandContext commandContext, CancellationToken cancellationToken = default);

    }
}
