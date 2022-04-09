using System;

namespace CRM.Application.Infrastructure.Exceptions.Contacts
{
    public class ContactNotFoundException : ApplicationException
    {
        private const string DefaultMessage = "Contact not found";

        public ContactNotFoundException() :base(DefaultMessage)
        {
                
        }

        public ContactNotFoundException(string message) :base(message)
        {
                
        }
    }
}