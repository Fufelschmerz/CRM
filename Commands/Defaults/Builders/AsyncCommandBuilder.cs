namespace Commands.Defaults.Builders
{
    using Commands.Absctractions.Builders;
    using Commands.Absctractions.Cotexts;
    using Commands.Absctractions.Factories;
    using System;
    using System.Threading;
    using System.Threading.Tasks;


    public class AsyncCommandBuilder : IAsyncCommandBuilder
    {
        private readonly IAsyncCommandFactory _commandFactory;

        public AsyncCommandBuilder(IAsyncCommandFactory commandFactory)
        {
            _commandFactory = commandFactory ??
                throw new ArgumentNullException(nameof(commandFactory));
        }

        public Task ExecuteAsync<T>(T commandContext, CancellationToken cancellationToken = default) 
            where T : ICommandContext
        {
            return _commandFactory.Create<T>().ExecuteAsync(commandContext, cancellationToken);
        }
    }
}
