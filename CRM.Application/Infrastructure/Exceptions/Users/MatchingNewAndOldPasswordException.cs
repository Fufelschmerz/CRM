namespace CRM.Application.Infrastructure.Exceptions.Users
{
    using System;

    public class MatchingNewAndOldPasswordException : ApplicationException
    {
        private const string DefaultMessage = "Matching the new and old password";

        public MatchingNewAndOldPasswordException():base(DefaultMessage)
        {

        }

        public MatchingNewAndOldPasswordException(string message) : base(message)
        {

        }
    }
}
