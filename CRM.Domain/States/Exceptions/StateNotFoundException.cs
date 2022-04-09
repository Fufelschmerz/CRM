namespace CRM.Domain.States.Exceptions
{
    using System;

    public class StateNotFoundException : Exception
    {
        private const string DefaultMessage = "State not found";

        public StateNotFoundException() : base(DefaultMessage)
        {

        }

        public StateNotFoundException(string message) : base(message)
        {

        }
    }
}
