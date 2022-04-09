namespace CRM.Application.Controllers.Contacts.Actions.Archive.Delete
{
    using System;
    using Api.Requests.Handlers;
    using System.Threading;
    using System.Threading.Tasks;
    using CRM.Application.Infrastructure.Exceptions.Contacts;
    using Queries.Abstractions.Builders;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.Contacts.Objects.Entities;

    public class DeleteContactToArchiveRequestHandler : IAsyncRequestHandler<DeleteContactToArchiveRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public DeleteContactToArchiveRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(DeleteContactToArchiveRequest request, CancellationToken cancellationToken = default)
        {
            var contact = await _queryBuilder.FindByIdAsync<Contact>(request.Id, cancellationToken) ??
                          throw new ContactNotFoundException();

            contact.DeleteContactArchive();
        }
    }
}