using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Common.Commands.Contexts;
using CRM.Persistence.ORM.Common.Repositories;
using Domain.Abstracions.Identification;
using Repositories.Abstractions;

namespace CRM.Persistence.ORM.Commands.Defaults
{
    public class DeleteObjWithIdCommand<T> : RepositoryAsyncCommandBase<T, DeleteCommandContext<T>>
        where T: class , IHasId, new()
    {
        public DeleteObjWithIdCommand(IAsyncRepository<T> repository) : base(repository) { }

        public override Task ExecuteAsync(DeleteCommandContext<T> commandContext, CancellationToken cancellationToken = default)
        {
            return Repository.DeleteAsync(commandContext.ObjWithId, cancellationToken);
        }
    }
}
