namespace CRM.Application.Infrastructure.Exceptions.Accounts
{
    using System;

    public class EmailIsIncorrectException : ApplicationException
    {
        private const string DefaultMessage = "Email is incorrent";

        public EmailIsIncorrectException():base(DefaultMessage)
        {

        }

        public EmailIsIncorrectException(string message) :base(message)
        {

        }
    }
}