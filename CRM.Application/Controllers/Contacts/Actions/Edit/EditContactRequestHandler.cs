using CRM.Domain.Contacts.Services.Abstractions;

namespace CRM.Application.Controllers.Contacts.Actions.Edit
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using Infrastructure.Exceptions.ContactData;
    using CRM.Application.Infrastructure.Exceptions.ContactPersons;
    using CRM.Application.Infrastructure.Exceptions.Contacts;
    using CRM.Application.Infrastructure.Exceptions.Users;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.ContactPersons.Objects.Entities;
    using CRM.Domain.ContactPersons.Objects.ValueObjects;
    using CRM.Domain.Contacts.Objects.Entities;
    using CRM.Domain.Users.Objects.Entities;
    using Queries.Abstractions.Builders;

    public class EditContactRequestHandler : IAsyncRequestHandler<EditContactRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public EditContactRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(EditContactRequest request, CancellationToken cancellationToken = default)
        {
            var contact = await _queryBuilder.FindByIdAsync<Contact>(request.Id, cancellationToken) ??
                          throw new ContactNotFoundException();

            var contactPerson = await _queryBuilder.FindByIdAsync<ContactPerson>(request.ContactPersonId, cancellationToken) ??
                                throw new ContactPersonNotFoundException();

            var contactData = await _queryBuilder.FindByIdAsync<ContactData>(request.ContactDataId, cancellationToken) ??
                              throw new ContactDataNotFoundException();

            var manager = await _queryBuilder.FindByIdAsync<User>(request.ManagerId, cancellationToken) ??
                          throw new UserNotFoundException();

            contact.CreateOrEditContact(contactPerson, contactData, request.Comment, manager, request.EventOfDate, request.State, request.PlannedEventOfDate);
        }
    }
}