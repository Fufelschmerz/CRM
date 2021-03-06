using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using CRM.Application.Infrastructure.Exceptions.ContactPersons;
using CRM.Domain.Common.Queries.Extensions;
using CRM.Domain.ContactPersons.Objects.Entities;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.ContactPersons.Actions.Archive.Add
{
    public class AddContactPersonToArchiveRequestHandler : IAsyncRequestHandler<AddContactPersonToArchiveRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public AddContactPersonToArchiveRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(AddContactPersonToArchiveRequest request, CancellationToken cancellationToken = default)
        {
            var contactPerson = await _queryBuilder.FindByIdAsync<ContactPerson>(request.Id, cancellationToken) ??
                                throw new ContactPersonNotFoundException();

            contactPerson.AddContactPersonToArchive();
        }
    }
}