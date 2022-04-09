namespace CRM.Application.Controllers.ContactPersons.Actions.Archive.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.ContactPersons.Objects.Entities;
    using Queries.Abstractions.Builders;
    using CRM.Application.Infrastructure.Exceptions.ContactPersons;


    public class DeleteContactPersonToArchiveRequestHandler : IAsyncRequestHandler<DeleteContactPersonToArchiveRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        public DeleteContactPersonToArchiveRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(DeleteContactPersonToArchiveRequest request, CancellationToken cancellationToken = default)
        {
            var contactPerson = await _queryBuilder.FindByIdAsync<ContactPerson>(request.Id, cancellationToken) ??
                                throw new ContactPersonNotFoundException();

            contactPerson.DeleteContactPersonToArchive();
        }
    }
}