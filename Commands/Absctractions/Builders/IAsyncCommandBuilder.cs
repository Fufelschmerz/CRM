namespace Commands.Absctractions.Builders
{
    using global::Commands.Absctractions.Cotexts;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAsyncCommandBuilder
    {
        Task ExecuteAsync<T>(T commandContext, CancellationToken cancellationToken = default)
            where T : ICommandContext;
    }
}
