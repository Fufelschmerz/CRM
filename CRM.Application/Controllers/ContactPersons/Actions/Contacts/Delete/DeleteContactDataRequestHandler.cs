namespace CRM.Application.Controllers.ContactPersons.Actions.Contacts.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Requests.Handlers;
    using Commands.Absctractions.Builders;
    using CRM.Domain.Common.Commands.Extensions;
    using CRM.Domain.Common.Queries.Extensions;
    using CRM.Domain.ContactPersons.Objects.ValueObjects;
    using Queries.Abstractions.Builders;

    public class DeleteContactDataRequestHandler :IAsyncRequestHandler<DeleteContactDataRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;

        private readonly IAsyncCommandBuilder _commandBuilder;

        public DeleteContactDataRequestHandler(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));

            _commandBuilder = commandBuilder ??
                              throw new ArgumentNullException(nameof(commandBuilder));
        }


        public async Task ExecuteAsync(DeleteContactDataRequest request, CancellationToken cancellationToken = default)
        {
            var contactData = await _queryBuilder.FindByIdAsync<ContactData>(request.Id, cancellationToken);

            await _commandBuilder.DeleteAsync(contactData, cancellationToken);
        }
    }
}