

using Persistence.Transactions;
using Persistence.Transactions.Behaviors;

namespace ApiControllers.Abstractions
{
    public interface IShouldPerformCommit
    {
        IExpectCommit CommitPerformer { get; }
    }
}
