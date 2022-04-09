using System.Threading;
using System.Threading.Tasks;
using CRM.Domain.Customers.Objects.Entities;
using CRM.Domain.Sources.Objects.Entities;
using CRM.Domain.States.Objects.Entities;
using Domain.Abstracions.Services;

namespace CRM.Domain.Customers.Services.Abstractions
{
    public interface ICustomerService : IDomainService
    {
        Task<Customer> CreateCustomerAsync(string name, Source source, State state, string description, CancellationToken cancellationToken = default);

        Task DeleteCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}
