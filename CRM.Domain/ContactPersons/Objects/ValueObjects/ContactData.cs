using System;
using CRM.Domain.ContactPersons.Enums;
using DataAnnotations;
using Domain.Abstracions.ValueObjects;

namespace CRM.Domain.ContactPersons.Objects.ValueObjects
{
    public class ContactData : IValueObjectHasId
    {
        [Obsolete("Constructor is only for reflection")]
        public ContactData()
        {

        }

        public ContactData(string value, string comment, ContactDataType contactDataType)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(nameof(value));

            Value = value;
            Comment = comment;
            ContactDataType = contactDataType;
        }

        public virtual long Id { get; protected set; }

        [Length(100)]
        public virtual string Value { get; protected set; }

        [Length(400)]
        [Nullable]
        public virtual string Comment { get; protected set; }

        public virtual ContactDataType ContactDataType { get; protected set; }
    }
}
