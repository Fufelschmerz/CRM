using Persistence.Transactions.Behaviors;

namespace CRM.Application.Controllers.States
{
    using System.Threading.Tasks;
    using Api.Requests.Builders.Abstractions;
    using ApiControllers.Default;
    using ApiControllers.Extensions;
    using Actions.Create;
    using Actions.Delete;
    using Actions.Edit;
    using Actions.Get;
    using Actions.GetList;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Authorization;
    using Actions.Archive.Add;
    using Actions.Archive.Delete;
    using Microsoft.AspNetCore.Authorization;

    [Authorize(Policy = Policies.Admin)]
    [Route("api/state")]
    public class StateController : ApiControllerBase
    {
        public StateController(IAsyncRequestBuilder asyncRequestBuilder, IExpectCommit commitPerformer)
            : base(asyncRequestBuilder, commitPerformer)
        {

        }

        [HttpPost]
        [Route("CreateState")]
        [ProducesResponseType(typeof(CreateStateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CreateStateRequest request)
            => this.RequestAsync()
            .For<CreateStateResponse>()
            .With(request);

        [HttpPost]
        [Route("EditState")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(EditStateRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("DeleteState")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Delete(DeleteStateRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("AddStateToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddStateToArchive(AddStateToArchiveRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("DeleteStateToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> DeleteStateToArchive(DeleteStateToArchiveRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("GetStateList")]
        [ProducesResponseType(typeof(GetStateListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetList(GetStateListRequest request)
            => this.RequestAsync()
            .For<GetStateListResponse>()
            .With(request);

        [HttpPost]
        [Route("GetStateById")]
        [ProducesResponseType(typeof(GetStateByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetById(GetStateByIdRequest request)
            => this.RequestAsync()
            .For<GetStateByIdResponse>()
            .With(request);
    }
}
