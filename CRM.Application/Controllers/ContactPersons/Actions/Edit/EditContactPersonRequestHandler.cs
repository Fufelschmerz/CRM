using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.Handlers;
using CRM.Application.Infrastructure.Exceptions.ContactPersons;
using CRM.Domain.Common.Queries.Extensions;
using CRM.Domain.ContactPersons.Objects.Entities;
using CRM.Domain.ContactPersons.Services.Abstractions;
using Queries.Abstractions.Builders;

namespace CRM.Application.Controllers.ContactPersons.Actions.Edit
{
    public class EditContactPersonRequestHandler : IAsyncRequestHandler<EditContactPersonRequest>
    {
        private readonly IAsyncQueryBuilder _queryBuilder;


        public EditContactPersonRequestHandler(IAsyncQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder ??
                            throw new ArgumentNullException(nameof(queryBuilder));
        }

        public async Task ExecuteAsync(EditContactPersonRequest request, CancellationToken cancellationToken = default)
        {
            var contactPerson = await _queryBuilder.FindByIdAsync<ContactPerson>(request.Id, cancellationToken) ??
                                throw new ContactPersonNotFoundException();


            contactPerson.CreateOrEditContactPerson(request.Name, request.Surname, request.Patronymic, request.Post, 
                request.Gender, request.ContactPersonComment, request.BirthDate);
        }
    }
}