using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Domain.ContactPersons.Enums;
using CRM.Domain.ContactPersons.Exceptions;
using CRM.Domain.ContactPersons.Objects.ValueObjects;
using DataAnnotations;
using Domain.Abstracions.Entities;

namespace CRM.Domain.ContactPersons.Objects.Entities
{
    public class ContactPerson : IEntity
    {
        private readonly ICollection<ContactData> _contactData = new HashSet<ContactData>();

        [Obsolete("Constructor is only for reflection")]
        public ContactPerson()
        {

        }

        public ContactPerson(string name, string surname, string patronymic, string post, Gender gender, string comment, DateTime birthDate, ContactData contactData = null)
        {
            CreateOrEditContactPerson(name, surname, patronymic, post, gender, comment, birthDate);

            if(contactData != null)
                AddContactData(contactData);

            IsArchive = false;
        }

        public virtual long Id { get; protected set; }

        [Length(60)]
        public virtual string Name { get; protected set; }

        [Length(60)]
        public virtual string Surname { get; protected set; }

        [Length(60)]
        public virtual string Patronymic { get; protected set; }

        [Length(100)]
        public virtual string Post { get; protected set; }

        public virtual Gender Gender { get; protected set; }

        [Length(400)]
        [Nullable]
        public virtual string Comment { get; protected set; }

        public virtual DateTime BirthDate { get; protected set; }

        public virtual bool IsArchive { get; protected set; }

        public virtual IEnumerable<ContactData> ContactData => _contactData;

        public virtual void CreateOrEditContactPerson(string name, string surname, string patronymic, string post, Gender gender, string comment, DateTime birthDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentException(nameof(surname));

            if (string.IsNullOrWhiteSpace(patronymic))
                throw new ArgumentException(nameof(patronymic));

            if (string.IsNullOrWhiteSpace(post))
                throw new ArgumentException(nameof(post));


            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Post = post;
            Gender = gender;
            BirthDate = birthDate;
            Comment = comment;
        }

        public virtual void AddContactData(ContactData contactData)
        {
            if (contactData == null)
                throw new ArgumentNullException(nameof(contactData));

            if (_contactData.Any(x => x.Value == contactData.Value && x.ContactDataType == contactData.ContactDataType))
                throw new ContactDataAlreadyExistsException();

            _contactData.Add(contactData);
        }

        public virtual void AddContactPersonToArchive()
        {
            IsArchive = true;
        }

        public virtual void DeleteContactPersonToArchive()
        {
            IsArchive = false;
        }
    }
}
