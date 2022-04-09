using System;

namespace CRM.Domain.Sources.Exceptions
{
    public class SourceAlreadyExistsException : Exception
    {
        private const string DefaultMessage = "A source with this name already exists";

        public SourceAlreadyExistsException() : base(DefaultMessage)
        {

        }

        public SourceAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
