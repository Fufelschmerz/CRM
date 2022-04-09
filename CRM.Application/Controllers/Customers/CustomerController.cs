using CRM.Application.Controllers.Customers.Actions.Archive.Add;
using CRM.Application.Controllers.Customers.Actions.Delete;
using CRM.Application.Controllers.Customers.Actions.GetList;
using Persistence.Transactions.Behaviors;

namespace CRM.Application.Controllers.Customers
{
    using System.Threading.Tasks;
    using ApiControllers.Default;
    using ApiControllers.Extensions;
    using Authorization;
    using Actions.Create;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Api.Requests.Builders.Abstractions;
    using Actions.Edit;
    using Actions.Get;
    using Actions.Archive.Delete;

    [Route("api/customer")]
    [Authorize(Policy = Policies.User)]
    public class CustomerController : ApiControllerBase
    {
        public CustomerController(IAsyncRequestBuilder asyncRequestBuilder, IExpectCommit commitPerformer)
            : base(asyncRequestBuilder, commitPerformer)
        {

        }

        [HttpPost]
        [Route("CreateCustomer")]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CreateCustomerRequest request)
            => this.RequestAsync()
                .For<CreateCustomerResponse>()
                .With(request);

        [HttpPost]
        [Route("EditCustomer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(EditCustomerRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("GetCustomerById")]
        [ProducesResponseType(typeof(GetCustomerByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetById(GetCustomerByIdRequest request)
            => this.RequestAsync()
                .For<GetCustomerByIdResponse>()
                .With(request);

        [HttpPost]
        [Route("DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Delete(DeleteCustomerRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("AddCustomerToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddCustomerToArchive(AddCustomerToArchiveRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("GetListCustomer")]
        [ProducesResponseType(typeof(GetCustomerListResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetList(GetCustomerListRequest request)
            => this.RequestAsync()
                .For<GetCustomerListResponse>()
                .With(request);

        [HttpPost]
        [Route("DeleteCustomerToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> DeleteCustomerToArchive(DeleteCustomerToArchiveRequest request)
            => this.RequestAsync(request);
    }
}