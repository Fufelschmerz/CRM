using Persistence.Transactions.Behaviors;

#if DEBUG
namespace CRM.Application.Controllers.Admins
{
    using System.Threading.Tasks;
    using Api.Requests.Builders.Abstractions;
    using ApiControllers.Default;
    using ApiControllers.Extensions;
    using Actions.Create;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/admin")]
    public class AdminController : ApiControllerBase
    {
        public AdminController(IAsyncRequestBuilder asyncRequestBuilder, IExpectCommit commitPerformer)
            : base(asyncRequestBuilder, commitPerformer)
        {

        }

        [HttpPost]
        [Route("CreateFirstAdmin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CreateFirstAdminRequest request)
            => this.RequestAsync(request);
    }
}
#endif
