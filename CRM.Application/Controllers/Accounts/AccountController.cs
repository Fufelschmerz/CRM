using Persistence.Transactions.Behaviors;

namespace CRM.Application.Controllers.Accounts
{
    using System.Threading.Tasks;
    using Api.Requests.Builders.Abstractions;
    using ApiControllers.Default;
    using ApiControllers.Extensions;
    using Authorization;
    using CRM.Application.Controllers.Accounts.Actions.Authorization;
    using Actions.SignIn;
    using Actions.SignOut;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/account")]
    [Authorize(Policy = Policies.User)]
    public class AccountController : ApiControllerBase
    {
        public AccountController(IAsyncRequestBuilder asyncRequestBuilder, IExpectCommit commitPerformer)
            : base(asyncRequestBuilder, commitPerformer)
        {

        }

        [HttpPost]
        [Route("IsAuthorized")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthorizationResponse), StatusCodes.Status200OK)]
        public Task<IActionResult> IsAuthorized(AuthorizationRequest request)
            => this.RequestAsync()
                .For<AuthorizationResponse>()
                .With(request);
        
        [HttpPost]
        [Route("SignIn")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> SignIn(SignInRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("SingOut")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> SignOut(SignOutRequest request)
            => this.RequestAsync(request);
    }
}