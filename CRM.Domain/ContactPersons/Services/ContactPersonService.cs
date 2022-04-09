using System;
using System.Threading;
using System.Threading.Tasks;
using Commands.Absctractions.Builders;
using CRM.Domain.Common.Commands.Extensions;
using CRM.Domain.ContactPersons.Enums;
using CRM.Domain.ContactPersons.Objects.Entities;
using CRM.Domain.ContactPersons.Objects.ValueObjects;
using CRM.Domain.ContactPersons.Services.Abstractions;
using CRM.Domain.Customers.Objects.Entities;

namespace CRM.Domain.ContactPersons.Services
{
    public class ContactPersonService : IContactPersonService
    {
        private readonly IAsyncCommandBuilder _commandBuilder;


        public ContactPersonService(IAsyncCommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder ??
                              throw new ArgumentNullException(nameof(commandBuilder));
        }

        public ContactPerson CreateContactPerson(Customer customer, string name, string surname, string patronymic,
            string post, Gender gender, string contactPersonComment, DateTime birthDate,
            ContactData contact = null)
        {
            var contactPerson = new ContactPerson(name, surname, patronymic, post, gender, contactPersonComment, birthDate, contact);

            customer.AddContactPerson(contactPerson);

            return contactPerson;
        }

        public async Task DeleteContactPersonAsync(ContactPerson contactPerson,
            CancellationToken cancellationToken = default)
        {
            await _commandBuilder.DeleteAsync(contactPerson, cancellationToken);
        }
    }
}
