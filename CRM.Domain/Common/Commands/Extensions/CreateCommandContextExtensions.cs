namespace CRM.Domain.Common.Commands.Extensions
{
    using CRM.Domain.Common.Commands.Contexts;
    using global::Commands.Absctractions.Builders;
    using global::Domain.Abstracions.Identification;
    using System.Threading;
    using System.Threading.Tasks;


    public static class CreateCommandContextExtensions
    {
        public static Task CreateAsync<T>(this IAsyncCommandBuilder asyncCommandBuilder, T objWithId, CancellationToken cancallationToken = default)
            where T : class, IHasId, new()
        {
            return asyncCommandBuilder.ExecuteAsync(new CreateCommandContext<T>(objWithId), cancallationToken);
        }
    }
}
