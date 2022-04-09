using Api.Responses.Abstractions;

namespace ApiControllers.Extensions
{
    using Api.Requests.Abstractions;
    using ApiControllers.Default;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public static class AsyncApiControllerBaseExtensions
    {
        public static Task<IActionResult> RequestAsync<TRequest, TResponse>(
            this ApiControllerBase apiController,
            TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
            => apiController.RequestAsync<ApiControllerBase, TRequest, TResponse>(request);

        public static Task<IActionResult> RequestAsync<TRequest, TResponse>(
            this ApiControllerBase apiController,
            TRequest request,
            Func<TResponse, IActionResult> success)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
            => apiController.RequestAsync<ApiControllerBase, TRequest, TResponse>(request, success);


        public static AsyncApiControllerBaseRequestBuilder RequestAsync(
            this ApiControllerBase apiController)
            => new(apiController);
    }
}
