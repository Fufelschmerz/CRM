using Api.Requests.Abstractions;
using Api.Requests.Handlers;
using Api.Responses.Abstractions;

namespace Api.Requests.Factory
{
    public interface IAsyncRequestHandlerFactory
    {
        IAsyncRequestHandler<TRequest> Create<TRequest>()
            where TRequest : IRequest;

        IAsyncRequestHandler<TRequest, TResponse> Create<TRequest, TResponse>()
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse;
    }
}
