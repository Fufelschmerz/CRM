using System;

namespace CRM.Application.Infrastructure.Exceptions.ContactPersons
{
    public class ContactPersonNotFoundException : ApplicationException
    {
        private const string DefaultMessage = "Contact person not found";
        public ContactPersonNotFoundException() : base(DefaultMessage)
        {

        }

        public ContactPersonNotFoundException(string message) : base(message)
        {

        }
    }
}
