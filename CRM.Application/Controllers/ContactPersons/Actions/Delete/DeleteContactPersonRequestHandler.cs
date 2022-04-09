using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using CRM.Application.Infrastructure.Exceptions.ContactPersons;
using CRM.Domain.Common.Queries.Extensions;
using CRM.Domain.ContactPersons.Objects.Entities;
using CRM.Domain.ContactPersons.Services.Abstractions;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.ContactPersons.Actions.Delete
{
    public class DeleteContactPersonRequestHandler :IAsyncRequestHandler<DeleteContactPersonRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IContactPersonService _contactPersonService;

        public DeleteContactPersonRequestHandler(IAsyncQueryBuilder queryBuilder, IContactPersonService contactPersonService)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _contactPersonService = contactPersonService ??
                                    throw new ArgumentNullException(nameof(contactPersonService));
        }


        public async Task ExecuteAsync(DeleteContactPersonRequest request, CancellationToken cancellationToken = default)
        {
            var contactPerson = await _queryBuilder.FindByIdAsync<ContactPerson>(request.Id, cancellationToken) ??
                                throw new ContactPersonNotFoundException();

            await _contactPersonService.DeleteContactPersonAsync(contactPerson, cancellationToken);
        }
    }
}