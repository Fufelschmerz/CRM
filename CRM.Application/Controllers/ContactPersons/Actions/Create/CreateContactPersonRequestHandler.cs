using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using CRM.Application.Infrastructure.Exceptions.Customers;
using CRM.Domain.Common.Queries.Extensions;
using CRM.Domain.ContactPersons.Objects.ValueObjects;
using CRM.Domain.ContactPersons.Services.Abstractions;
using CRM.Domain.Customers.Objects.Entities;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.ContactPersons.Actions.Create
{
    public class CreateContactPersonRequestHandler : IAsyncRequestHandler<CreateContactPersonRequest, CreateContactPersonResponse>
    {
        private readonly IContactPersonService _contactPersonService;
        private readonly IAsyncQueryBuilder _queryBuilder;

        public CreateContactPersonRequestHandler(IContactPersonService contactPersonService, IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _contactPersonService = contactPersonService ??
                throw new ArgumentNullException(nameof(contactPersonService));
        }

        public async Task<CreateContactPersonResponse> ExecuteAsync(CreateContactPersonRequest request, CancellationToken cancellationToken = default)
        {
            var customer = await _queryBuilder.FindByIdAsync<Customer>(request.CustomerId, cancellationToken) ??
                           throw new CustomerNotFoundException();

            var contactData = new ContactData(request.ContactValue, request.ContactComment, request.ContactDataType);

            var contactPerson = _contactPersonService.CreateContactPerson(customer, request.Name, request.Surname, request.Patronymic, request.Post,
                request.Gender, request.ContactPersonComment, request.BirthDate, contactData);

            return new CreateContactPersonResponse { Id = contactPerson.Id };
        }
    }
}
