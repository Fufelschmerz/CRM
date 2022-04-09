namespace CRM.Domain.Common.Commands.Extensions
{
    using CRM.Domain.Common.Commands.Contexts;
    using global::Commands.Absctractions.Builders;
    using global::Domain.Abstracions.Identification;
    using System.Threading;
    using System.Threading.Tasks;

    public static class DeleteCommandContextExtensions
    {
        public static Task DeleteAsync<T> (this IAsyncCommandBuilder asyncCommandBuilder, T objWithId, CancellationToken cancellationToken = default)
            where T: class, IHasId, new()
        {
            return asyncCommandBuilder.ExecuteAsync(new DeleteCommandContext<T>(objWithId), cancellationToken);
        }
    }
}
