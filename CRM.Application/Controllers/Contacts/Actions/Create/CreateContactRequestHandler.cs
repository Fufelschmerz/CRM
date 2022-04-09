namespace CRM.Application.Controllers.Contacts.Actions.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Contacts.Services.Abstractions;
    using CRM.Domain.Customers.Objects.Entities;
    using Queries.Abstractions.Builders;
    using Infrastructure.Exceptions.ContactData;
    using CRM.Application.Infrastructure.Exceptions.ContactPersons;
    using CRM.Application.Infrastructure.Exceptions.Customers;
    using CRM.Application.Infrastructure.Exceptions.Users;
    using CRM.Domain.ContactPersons.Objects.Entities;
    using CRM.Domain.ContactPersons.Objects.ValueObjects;
    using CRM.Domain.Users.Objects.Entities;

    public class CreateContactRequestHandler : IAsyncRequestHandler<CreateContactRequest, CreateContactResponse>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IContactService _contactService;

        public CreateContactRequestHandler(IAsyncQueryBuilder queryBuilder, IContactService contactService)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _contactService = contactService ??
                              throw new ArgumentNullException(nameof(contactService));
        }

        public async Task<CreateContactResponse> ExecuteAsync(CreateContactRequest request, CancellationToken cancellationToken = default)
        {
            var customer = await _queryBuilder.FindByIdAsync<Customer>(request.CustomerId, cancellationToken) ??
                           throw new CustomerNotFoundException();

            var contactPerson = await _queryBuilder.FindByIdAsync<ContactPerson>(request.ContactPersonId, cancellationToken) ??
                                  throw new ContactPersonNotFoundException();

            var contactData = await _queryBuilder.FindByIdAsync<ContactData>(request.ContactDataId, cancellationToken) ??
                              throw new ContactDataNotFoundException();

            var manager = await _queryBuilder.FindByIdAsync<User>(request.ManagerId, cancellationToken) ?? 
                          throw new UserNotFoundException();

            var contact  = _contactService.CreateContact(customer, contactPerson, contactData, request.Comment, manager, request.EventOfDate, request.State, request.PlannedEventOfDate, 
                cancellationToken);

            return new CreateContactResponse {Id = contact.Id};
        }
    }
}