using Api.Responses.Abstractions;

namespace ApiControllers.Abstractions
{
    using Microsoft.AspNetCore.Mvc;
    using System;

    public interface IHasDefaultResponseSuccessActionResult
    {
        Func<TResponse, IActionResult> ResponseSuccess<TResponse>()
            where TResponse : IResponse;
    }
}
