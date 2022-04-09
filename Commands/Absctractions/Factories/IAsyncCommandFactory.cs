namespace Commands.Absctractions.Factories
{
    using global:: Commands.Absctractions.Commands;
    using global:: Commands.Absctractions.Cotexts;

    public interface IAsyncCommandFactory
    {
        IAsyncCommand<T> Create<T>() where T : ICommandContext;
    }
}
