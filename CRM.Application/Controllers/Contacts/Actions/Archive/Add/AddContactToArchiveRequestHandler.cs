namespace CRM.Application.Controllers.Contacts.Actions.Archive.Add
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Application.Infrastructure.Exceptions.Contacts;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Contacts.Objects.Entities;
    using Queries.Abstractions.Builders;

    public class AddContactToArchiveRequestHandler : IAsyncRequestHandler<AddContactToArchiveRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public AddContactToArchiveRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(AddContactToArchiveRequest request, CancellationToken cancellationToken = default)
        {
            var contact = await _queryBuilder.FindByIdAsync<Contact>(request.Id, cancellationToken) ?? 
                          throw new ContactNotFoundException();


            contact.AddContactArchive();
        }
    }
}