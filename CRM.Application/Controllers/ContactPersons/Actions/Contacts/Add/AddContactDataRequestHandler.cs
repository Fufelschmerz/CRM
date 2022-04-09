namespace CRM.Application.Controllers.ContactPersons.Actions.Contacts.Add
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.ContactPersons;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.ContactPersons.Objects.Entities;
    using CRM.Domain.ContactPersons.Objects.ValueObjects;
    using CRM.Domain.ContactPersons.Services.Abstractions;
    using Queries.Abstractions.Builders;

    public class AddContactDataRequestHandler : IAsyncRequestHandler<AddContactDataRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IContactPersonService _contactPersonService;

        public AddContactDataRequestHandler(IAsyncQueryBuilder queryBuilder, IContactPersonService contactPersonService)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _contactPersonService = contactPersonService ??
                                    throw new ArgumentNullException(nameof(contactPersonService));
        }

        public async Task ExecuteAsync(AddContactDataRequest request, CancellationToken cancellationToken = default)
        {
            var contactPerson = await _queryBuilder.FindByIdAsync<ContactPerson>(request.ContactPersonId, cancellationToken) ??
                                throw new ContactPersonNotFoundException();

            var contactData = new ContactData(request.Value, request.Comment, request.ContactDataType);

            contactPerson.AddContactData(contactData);
        }
    }
}