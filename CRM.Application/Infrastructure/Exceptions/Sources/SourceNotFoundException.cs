using System;

namespace CRM.Application.Infrastructure.Exceptions.Sources
{
    public class SourceNotFoundException : ApplicationException
    {
        private const string DefaultMessage = "Source not found";

        public SourceNotFoundException() : base(DefaultMessage)
        {

        }

        public SourceNotFoundException(string message) : base(message)
        {

        }
    }
}
