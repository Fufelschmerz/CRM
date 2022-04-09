using Api.Requests.Factory;
using Api.Responses.Abstractions;

namespace Api.Requests.Builders.Defaults
{
    using Api.Requests.Abstractions;
    using Api.Requests.Builders.Abstractions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DefaultAsyncRequestBuilder : IAsyncRequestBuilder
    {
        private readonly IAsyncRequestHandlerFactory _requestHandlerFactory;

        public DefaultAsyncRequestBuilder(IAsyncRequestHandlerFactory requestHandlerFactory)
        {
            _requestHandlerFactory = requestHandlerFactory ??
                throw new ArgumentNullException(nameof(requestHandlerFactory));
        }

        public Task ExecuteAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
        {
            return _requestHandlerFactory.Create<TRequest>().ExecuteAsync(request, cancellationToken);
        }

        public Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            return _requestHandlerFactory.Create<TRequest, TResponse>().ExecuteAsync(request, cancellationToken);
        }
    }
}
