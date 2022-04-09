namespace CRM.Application.Infrastructure.Exceptions.Customers
{
    using System;

    public class CustomerNotFoundException :ApplicationException
    {
        private const string DefaultMessage = "Customer not found";

        public CustomerNotFoundException(): base(DefaultMessage)
        {
                
        }

        public CustomerNotFoundException(string message) : base(message)
        {

        }
    }
}