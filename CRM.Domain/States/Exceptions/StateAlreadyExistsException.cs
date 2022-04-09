namespace CRM.Domain.States.Exceptions
{
    using System;

    public class StateAlreadyExistsException : Exception
    {
        private const string DefaultMessage = "The state with the name there already exists";

        public StateAlreadyExistsException() : base(DefaultMessage)
        {

        }

        public StateAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
