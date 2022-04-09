namespace Commands.Absctractions.Commands
{
    using global::Commands.Absctractions.Cotexts;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAsyncCommand<in T> where T: ICommandContext
    {
        Task ExecuteAsync(T commandContext, CancellationToken cancellationToken = default);
    }
}
