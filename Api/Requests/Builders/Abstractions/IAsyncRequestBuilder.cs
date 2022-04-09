using Api.Responses.Abstractions;

namespace Api.Requests.Builders.Abstractions
{
    using Api.Requests.Abstractions;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAsyncRequestBuilder
    {
        Task ExecuteAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest;

        Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse;
    }
}
