﻿using Api.Responses.Abstractions;

namespace ApiControllers.Extensions
{
    using ApiControllers.Default;

    public class AsyncApiControllerBaseRequestBuilder
    {
        private readonly ApiControllerBase _apiController;

        public AsyncApiControllerBaseRequestBuilder(ApiControllerBase apiController)
        {
            _apiController = apiController;
        }

        public AsyncApiControllerBaseRequestFor<TResponse> For<TResponse>()
            where TResponse : IResponse
            => new(_apiController);
    }
}
