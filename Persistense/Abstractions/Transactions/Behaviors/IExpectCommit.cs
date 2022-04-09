namespace Persistence.Abstractions.Transactions.Behaviors
{
    public interface IExpectCommit
    {
        void PerformCommit();
    }
}
