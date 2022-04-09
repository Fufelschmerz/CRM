using System;
using System.Threading;
using System.Threading.Tasks;
using Commands.Absctractions.Builders;
using CRM.Domain.Common.Commands.Extensions;
using CRM.Domain.Customers.Objects.Entities;
using CRM.Domain.Customers.Services.Abstractions;
using CRM.Domain.Sources.Objects.Entities;
using CRM.Domain.States.Objects.Entities;

namespace CRM.Domain.Customers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAsyncCommandBuilder _commandBuilder;

        public CustomerService(IAsyncCommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder ??
                              throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task<Customer> CreateCustomerAsync(string name, Source source, State state, string description,
            CancellationToken cancellationToken = default)
        {
            var customer = new Customer(name, source, state, description);

            await _commandBuilder.CreateAsync(customer, cancellationToken);

            return customer;
        }

        public async Task DeleteCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            await _commandBuilder.DeleteAsync(customer, cancellationToken);
        }
    }
}
