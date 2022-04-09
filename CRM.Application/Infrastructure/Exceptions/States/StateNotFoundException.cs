namespace CRM.Application.Infrastructure.Exceptions.States
{
    using System;

    public class StateNotFoundException : ApplicationException
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