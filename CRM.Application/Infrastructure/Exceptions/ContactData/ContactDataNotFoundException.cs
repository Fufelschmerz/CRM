namespace CRM.Application.Infrastructure.Exceptions.ContactData
{
    using System;

    public class ContactDataNotFoundException : ApplicationException
    {
        private const string DefaultMessage = "Contact data not found";

        public ContactDataNotFoundException() : base(DefaultMessage)
        {
                
        }

        public ContactDataNotFoundException(string message) :base(message)
        {
                
        }
    }
}