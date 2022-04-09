using Persistence.Transactions.Behaviors;

namespace CRM.Application.Controllers.Sources
{
    using Actions.Archive.Add;
    using Actions.Archive.Delete;
    using Api.Requests.Builders.Abstractions;
    using ApiControllers.Default;
    using Microsoft.AspNetCore.Mvc;
    using Actions.Get;
    using Actions.Delete;
    using Microsoft.AspNetCore.Http;
    using ApiControllers.Extensions;
    using System.Threading.Tasks;
    using Actions.GetList;
    using Actions.Edit;
    using Actions.Create;
    using Authorization;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/source")]
    [Authorize(Policy = Policies.Admin)]
    public class SourceController : ApiControllerBase
    {
        public SourceController(IAsyncRequestBuilder asyncRequestBuilder, IExpectCommit commitPerformer)
            : base(asyncRequestBuilder, commitPerformer)
        {

        }

        [HttpPost]
        [Route("CreateSource")]
        [ProducesResponseType(typeof(CreateSourceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CreateSourceRequest request)
            => this.RequestAsync()
            .For<CreateSourceResponse>()
            .With(request);

        [HttpPost]
        [Route("EditSource")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(EditSourceRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("DeleteSource")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Delete(DeleteSourceRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("AddSourceToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddSourceToArchive(AddSourceToArchiveRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("DeleteSourceToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> DeleteSourceToArchive(DeleteSourceToArchiveRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("GetSourceList")]
        [ProducesResponseType(typeof(GetSourceListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetList(GetSourceListRequest request)
            => this.RequestAsync()
            .For<GetSourceListResponse>()
            .With(request);

        [HttpPost]
        [Route("GetSourceById")]
        [ProducesResponseType(typeof(GetSourceByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetById(GetSourceByIdRequest request)
            => this.RequestAsync()
            .For<GetSourceByIdResponse>()
            .With(request);
    }
}
