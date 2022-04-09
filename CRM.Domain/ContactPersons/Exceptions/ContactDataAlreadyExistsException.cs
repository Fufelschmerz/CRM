namespace CRM.Domain.ContactPersons.Exceptions
{
    using System;

    public class ContactDataAlreadyExistsException : Exception
    {
        private const string DefaultMessage = "Contact data already exists";

        public ContactDataAlreadyExistsException() : base(DefaultMessage)
        {
            
        }

        public ContactDataAlreadyExistsException(string message) : base(message)
        {
            
        }
    }
}