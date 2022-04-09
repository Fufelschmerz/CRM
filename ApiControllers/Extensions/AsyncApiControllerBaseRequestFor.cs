using Api.Responses.Abstractions;

namespace ApiControllers.Extensions
{
    using Api.Requests.Abstractions;
    using ApiControllers.Default;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AsyncApiControllerBaseRequestFor<TResponse>
        where TResponse : IResponse
    {
        private readonly ApiControllerBase _apiController;

        public AsyncApiControllerBaseRequestFor(ApiControllerBase apiController)
        {
            _apiController = apiController;
        }

        public Task<IActionResult> With<TRequest>(TRequest request)
            where TRequest : IRequest<TResponse>
            => _apiController.RequestAsync<ApiControllerBase, TRequest, TResponse>(request);
    }
}
