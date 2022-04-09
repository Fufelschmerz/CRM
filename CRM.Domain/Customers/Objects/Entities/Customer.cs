using System.Linq;
using CRM.Domain.ContactPersons.Objects.Entities;
using CRM.Domain.Contacts.Objects.Entities;
using CRM.Domain.Sources.Objects.Entities;
using DataAnnotations;

namespace CRM.Domain.Customers.Objects.Entities
{
    using CRM.Domain.States.Objects.Entities;
    using global::Domain.Abstracions.Entities;
    using System;
    using System.Collections.Generic;

    public class Customer : IEntity
    {
        private readonly ICollection<ContactPerson> _contactPersons = new List<ContactPerson>();

        private readonly ICollection<Contact> _contacts = new List<Contact>();

        [Obsolete("Constructor is only for reflection")]
        public Customer()
        {

        }

        public Customer(string name, Source source, State state, string description)
        {
            CreateOrEditCustomer(name, source, state, description);

            DateCreated = DateTime.Now;

            IsArchive = false;
        }


        public virtual long Id { get; protected set; }

        [Length(100)]
        public virtual string Name { get; protected set; }

        public virtual Source Source { get; protected set; }

        public virtual State State { get; protected set; }

        [Nullable]
        [Length(600)]
        public virtual string Description { get; protected set; }

        public virtual DateTime DateCreated { get; protected set; }

        public virtual bool IsArchive { get; protected set; }

        public virtual IEnumerable<ContactPerson> ContactPersons => _contactPersons;

        public virtual IEnumerable<Contact> Contacts => _contacts;

        public virtual IEnumerable<Contact> OrderedContacts =>
            _contacts.AsQueryable().OrderByDescending(x => x.CreationOfDate);

        public virtual void CreateOrEditCustomer(string name, Source source, State state, string description)
        {

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            Source = source ??
                     throw new ArgumentNullException(nameof(source));

            State = state ??
                throw new ArgumentNullException(nameof(state));

            Name = name;

            Description = description;
        }

        protected internal virtual void AddContactPerson(ContactPerson contactPerson)
        {
            if (contactPerson == null)
                throw new ArgumentNullException(nameof(contactPerson));

            _contactPersons.Add(contactPerson);
        }

        protected internal virtual void AddContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _contacts.Add(contact);
        }

        public virtual void AddCustomerToArchive()
        {
            IsArchive = true;
        }

        public virtual void DeleteCustomerToArchive()
        {
            IsArchive = false;
        }
    }
}
