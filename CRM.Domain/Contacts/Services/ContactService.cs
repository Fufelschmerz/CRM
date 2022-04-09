using System.Threading;

namespace CRM.Domain.Contacts.Services
{
    using Abstractions;
    using System;
    using CRM.Domain.ContactPersons.Objects.Entities;
    using CRM.Domain.ContactPersons.Objects.ValueObjects;
    using Objects.Entities;
    using CRM.Domain.Customers.Objects.Entities;
    using CRM.Domain.Users.Objects.Entities;
    using Enums;

    public class ContactService :IContactService
    {
        public Contact CreateContact(Customer customer, ContactPerson contactPerson, ContactData contactData, string comment, User manager, DateTime eventOfDate, StateContact stateContact, DateTime plannedEventOfDate, CancellationToken cancellationToken = default)
        {
            var contact = new Contact(contactPerson, contactData, comment, manager, eventOfDate, stateContact,
                plannedEventOfDate);

            customer.AddContact(contact);

            return contact;
        }
    }
}