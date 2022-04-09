using System.Threading.Tasks;
using Api.Requests.Builders.Abstractions;
using ApiControllers.Default;
using ApiControllers.Extensions;
using CRM.Application.Authorization;
using CRM.Application.Controllers.ContactPersons.Actions.Archive.Add;
using CRM.Application.Controllers.ContactPersons.Actions.Archive.Delete;
using CRM.Application.Controllers.ContactPersons.Actions.Contacts.Add;
using CRM.Application.Controllers.ContactPersons.Actions.Contacts.Delete;
using CRM.Application.Controllers.ContactPersons.Actions.Create;
using CRM.Application.Controllers.ContactPersons.Actions.Delete;
using CRM.Application.Controllers.ContactPersons.Actions.Edit;
using CRM.Application.Controllers.ContactPersons.Actions.Get;
using CRM.Application.Controllers.ContactPersons.Actions.GetList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Transactions.Behaviors;

namespace CRM.Application.Controllers.ContactPersons
{
    [Authorize(Policy = Policies.User)]
    [Route("api/source")]
    public class ContactPersonController : ApiControllerBase
    {
        public ContactPersonController(IAsyncRequestBuilder asyncRequestBuilder, IExpectCommit commitPerformer)
            : base(asyncRequestBuilder, commitPerformer)
        {

        }

        [HttpPost]
        [Route("CreateContactPerson")]
        [ProducesResponseType(typeof(CreateContactPersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CreateContactPersonRequest request)
            => this.RequestAsync()
            .For<CreateContactPersonResponse>()
            .With(request);

        [HttpPost]
        [Route("EditContactPerson")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(EditContactPersonRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("DeleteContactPerson")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Delete(DeleteContactPersonRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("GetContactPersonById")]
        [ProducesResponseType(typeof(GetContactPersonByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetById(GetContactPersonByIdRequest request)
            => this.RequestAsync()
                .For<GetContactPersonByIdResponse>()
                .With(request);

        [HttpPost]
        [Route("AddContactData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddContact(AddContactDataRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("DeleteContactData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> DeleteContact(DeleteContactDataRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("AddContactPersonToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddToArchive(AddContactPersonToArchiveRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("GetContactPersonList")]
        [ProducesResponseType(typeof(GetListContactPersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetList(GetListContactPersonRequest request)
            => this.RequestAsync()
                .For<GetListContactPersonResponse>()
                .With(request);

        [HttpPost]
        [Route("DeleteContactPersonToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddToArchive(DeleteContactPersonToArchiveRequest request)
            => this.RequestAsync(request);
    }
}
