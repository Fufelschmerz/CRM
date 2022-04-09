using System.Threading.Tasks;
using ApiControllers.Extensions;
using CRM.Application.Controllers.Files.Customers.Actions;
using Microsoft.AspNetCore.Http;
using Persistence.Transactions.Behaviors;

namespace CRM.Application.Controllers.Files
{
    using Api.Requests.Builders.Abstractions;
    using ApiControllers.Default;
    using Authorization;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/file")]
    [Authorize(Policy = Policies.User)]
    public class FileController : ApiControllerBase
    {
        public FileController(IAsyncRequestBuilder asyncRequestBuilder, IExpectCommit commitPerformer)
            : base(asyncRequestBuilder, commitPerformer)
        {

        }

        [HttpPost]
        [Route("ExportCustomersToExcel")]
        [Authorize(Policy = Policies.Admin)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> ExportCustomersToExcel(ExportCustomerToExcelRequest request)
            => this.RequestAsync(request);
    }
}
