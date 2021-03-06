using Api.Responses.Abstractions;
using Persistence.Transactions.Behaviors;

namespace ApiControllers.Default
{
    using Api.Requests.Builders.Abstractions;
    using Abstractions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;

    [ApiController]
    public class ApiControllerBase
        : ControllerBase,
            IAsyncApiController,
            IHasDefaultSuccessActionResult,
            IHasDefaultResponseSuccessActionResult,
            IHasDefaultFailActionResult,
            IHasInvalidModelStateActionResult,
            IShouldPerformCommit
    {
        private readonly IAsyncRequestBuilder _asyncRequestBuilder;
        private readonly IExpectCommit _commitPerformer;



        public ApiControllerBase(
            IAsyncRequestBuilder asyncRequestBuilder,
            IExpectCommit commitPerformer)
        {
            _asyncRequestBuilder = asyncRequestBuilder ?? 
                throw new ArgumentNullException(nameof(asyncRequestBuilder));
            _commitPerformer = commitPerformer ?? 
                throw new ArgumentNullException(nameof(commitPerformer));
        }



        public virtual Func<IActionResult> Success
            => () => new OkResult();

        public virtual Func<TResponse, IActionResult> ResponseSuccess<TResponse>()
            where TResponse : IResponse
            => (TResponse response) => new OkObjectResult(response);


        public virtual Func<Exception, IActionResult> Fail
            => (Exception exception) => new BadRequestObjectResult(exception.Message);

        public virtual Func<ModelStateDictionary, IActionResult> InvalidModelState
            => (ModelStateDictionary modelState) => new BadRequestObjectResult(new ValidationProblemDetails(modelState).Errors);



        IAsyncRequestBuilder IAsyncApiController.AsyncRequestBuilder => _asyncRequestBuilder;

        IExpectCommit IShouldPerformCommit.CommitPerformer => _commitPerformer;

    }
}
