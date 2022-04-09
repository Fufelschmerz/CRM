namespace CRM.Domain.Contacts.Services.Abstractions
{
    using System;
    using System.Threading;
    using CRM.Domain.Contacts.Enums;
    using CRM.Domain.Customers.Objects.Entities;
    using CRM.Domain.ContactPersons.Objects.Entities;
    using CRM.Domain.ContactPersons.Objects.ValueObjects;
    using CRM.Domain.Users.Objects.Entities;
    using Objects.Entities;
    using global::Domain.Abstracions.Services;

    public interface IContactService : IDomainService
    {
        Contact CreateContact(Customer customer, ContactPerson contactPerson, ContactData contactData,
            string comment, User manager, DateTime eventOfDate, StateContact stateContact, DateTime plannedEventOfDate, CancellationToken cancellationToken = default);
    }
}