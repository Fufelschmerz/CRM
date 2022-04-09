using System;
using CRM.Application.Controllers.Contacts.Actions.Archive.Add;
using CRM.Application.Controllers.Contacts.Actions.Edit;
using CRM.Application.Controllers.Contacts.Actions.Get;
using CRM.Application.Controllers.Contacts.Actions.GetList;
using Microsoft.AspNetCore.Authorization;
using Persistence.Transactions.Behaviors;

namespace CRM.Application.Controllers.Contacts
{
    using System.Threading.Tasks;
    using ApiControllers.Extensions;
    using ApiControllers.Default;
    using Authorization;
    using Api.Requests.Builders.Abstractions;
    using Microsoft.AspNetCore.Mvc;
    using Actions.Create;
    using Microsoft.AspNetCore.Http;
    using Actions.Archive.Delete;

    [Route("api/contact")]
    [Authorize(Policy = Policies.ManagerOrAdmin)]
    public class ContactController : ApiControllerBase
    {
        public ContactController(IAsyncRequestBuilder asyncRequestBuilder, IExpectCommit commitPerformer)
            : base(asyncRequestBuilder, commitPerformer)
        {

        }

        [HttpPost]
        [Route("CreateContact")]
        [ProducesResponseType(typeof(CreateContactResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CreateContactRequest request)
            => this.RequestAsync()
                .For<CreateContactResponse>()
                .With(request);

        [HttpPost]
        [Route("AddContactToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> AddToArchive(AddContactToArchiveRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("DeleteContactToArchive")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> DeleteToArchive(DeleteContactToArchiveRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("EditContact")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(EditContactRequest request)
            => this.RequestAsync(request);

        [HttpPost]
        [Route("GetContactListForManager")]
        [ProducesResponseType(typeof(GetContactListForManagerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetContactList(GetContactListForManagerRequest forManagerRequest)
            => this.RequestAsync()
                .For<GetContactListForManagerResponse>()
                .With(forManagerRequest);

        [HttpPost]
        [Route("GetContactById")]
        [ProducesResponseType(typeof(GetContactByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> GetContactById(GetContactByIdRequest request)
            => this.RequestAsync()
                .For<GetContactByIdResponse>()
                .With(request);
    }
}