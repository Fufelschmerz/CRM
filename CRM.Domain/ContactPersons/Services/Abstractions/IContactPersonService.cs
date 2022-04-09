namespace CRM.Domain.ContactPersons.Services.Abstractions
{
    using Objects.Entities;
    using Objects.ValueObjects;
    using CRM.Domain.Customers.Objects.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Enums;
    using global::Domain.Abstracions.Services;


    public interface IContactPersonService : IDomainService
    {
        ContactPerson CreateContactPerson(Customer customer, string name, string surname, string patronymic, string post,
            Gender gender, string contactPersonComment, DateTime birthDate, ContactData contact);

        Task DeleteContactPersonAsync(ContactPerson contactPerson, CancellationToken cancellationToken = default);
    }
}
