namespace Api.Requests.Handlers
{
    using Api.Requests.Abstractions;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAsyncRequestHandler<in TRequest> where TRequest : IRequest
    {
        Task ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
    }


}
