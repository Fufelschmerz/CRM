using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Common.Commands.Contexts;
using CRM.Persistence.ORM.Common.Repositories;
using Domain.Abstracions.Identification;
using Repositories.Abstractions;

namespace CRM.Persistence.ORM.Commands.Defaults
{
    public class CreateObjWithIdCommand<T> : RepositoryAsyncCommandBase<T, CreateCommandContext<T>>
        where T: class, IHasId, new ()
    {
        public CreateObjWithIdCommand(IAsyncRepository<T> repository) : base (repository)
        {

        }

        public override Task ExecuteAsync(CreateCommandContext<T> commandContext, CancellationToken cancellationToken = default)
        {
            return Repository.AddAsync(commandContext.ObjWithId, cancellationToken);
        }
    }
}
