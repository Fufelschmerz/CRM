using CRM.Application.Controllers.Users.Actions.GetList;
using Persistence.Transactions.Behaviors;

namespace CRM.Application.Controllers.Users
{
    using Api.Requests.Builders.Abstractions;
    using ApiControllers.Default;
    using Authorization;
    using Actions.Create;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using ApiControllers.Extensions;
    using Actions.Edit;
    using Actions.Delete;
    using Actions.Blocking.Block;
    using Actions.Blocking.Unlock;
    using Actions.Get;
    using Actions.ChangePassword;

    [Route("api/user")]
    public class UserController : ApiControllerBase
    {
        public UserController(IAsyncRequestBuilder asyncRequestBuilder, IExpectCommit commitPerformer)
            : base(asyncRequestBuilder, commitPerformer)
        {

        }

        [HttpPost]
        [Route("CreateUser")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CreateUserRequest request)
            => this.RequestAsync()
            .For<CreateUserResponse>()
            .With(request);

        [HttpPost]
        [Route("EditUser")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(EditUserRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("DeleteUser")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Delete(DeleteUserRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("Block")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Block(BlockUserRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("Unlock")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Unlock(UnlockUserRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("GetUserById")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(typeof(GetUserByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetById(GetUserByIdRequest request)
            => this.RequestAsync()
            .For<GetUserByIdResponse>()
            .With(request);

        [HttpPost]
        [Route("GetUserList")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(typeof(GetUserListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetList(GetUserListRequest request)
            => this.RequestAsync()
                .For<GetUserListResponse>()
                .With(request);

        [HttpPost]
        [Route("ChangePassword")]
        [Authorize(Policy = Policies.User)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> ChangePassword(ChangePasswordRequest request)
            => this.RequestAsync(request);
    }
}
