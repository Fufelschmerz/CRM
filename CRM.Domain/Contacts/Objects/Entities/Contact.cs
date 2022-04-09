using CRM.Domain.Contacts.Enums;
using CRM.Domain.Users.Enums;

namespace CRM.Domain.Contacts.Objects.Entities
{
    using System;
    using CRM.Domain.ContactPersons.Objects.ValueObjects;
    using CRM.Domain.Users.Objects.Entities;
    using DataAnnotations;
    using CRM.Domain.ContactPersons.Objects.Entities;
    using global::Domain.Abstracions.Entities;

    public class Contact : IEntity
    {
        [Obsolete("Constructor is only for reflection")]
        public Contact()
        {
            
        }

        public Contact(ContactPerson contactPerson, ContactData contactData,
            string comment, User manager, DateTime eventOfDate, StateContact stateContact, DateTime plannedEventOfDate)
        {
            CreateOrEditContact(contactPerson, contactData, comment, manager, eventOfDate, stateContact, plannedEventOfDate);

            CreationOfDate = DateTime.Now;

            IsArchive = false;
        }

        public virtual long Id { get; protected set; }

        public virtual ContactPerson ContactPerson { get; protected set; }

        public virtual ContactData ContactData { get; protected set; }

        [Length(4000)]
        public virtual string Comment { get; protected set; }

        public virtual User Manager { get; protected set; }

        public virtual DateTime CreationOfDate { get; protected set; }

        public virtual DateTime EventOfDate { get; protected set; }

        public virtual DateTime PlannedEventOfDate { get; protected set; }

        public virtual StateContact StateContact { get; protected set; }

        public virtual bool IsArchive { get; protected set; }

        public virtual void CreateOrEditContact(ContactPerson contactPerson, ContactData contactData,
            string comment, User manager, DateTime eventOfDate, StateContact stateContact, DateTime plannedEventOfDate)
        {
            if (manager == null)
                throw new ArgumentNullException(nameof(manager));

            if (manager.UserRole != UserRoles.Admin || manager.UserRole != UserRoles.Manager)
                throw new ArgumentException(nameof(manager));

            Manager = manager;

            ContactPerson = contactPerson ??
                            throw new ArgumentNullException(nameof(contactPerson));

            ContactData = contactData ??
                          throw new ArgumentNullException(nameof(contactData));

            StateContact = stateContact;

            EventOfDate = eventOfDate;

            PlannedEventOfDate = plannedEventOfDate;

            Comment = comment;
        }

        public virtual void AddContactArchive()
        {
            IsArchive = true;
        }

        public virtual void DeleteContactArchive()
        {
            IsArchive = false;
        }
    }
}