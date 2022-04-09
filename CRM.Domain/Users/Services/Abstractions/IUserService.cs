namespace CRM.Domain.Users.Services.Abstractions
{
    using CRM.Domain.Users.Enums;
    using CRM.Domain.Users.Objects.Entities;
    using global::Domain.Abstracions.Services;
    using System.Threading;
    using System.Threading.Tasks;


    public interface IUserService : IDomainService 
    {
        Task<User> CreateUserAsync(string email, string name, string password, UserRoles userRole, CancellationToken cancellationToken = default);

        Task DeleteUserAsync(User user, CancellationToken cancellationToken = default);

        Task EditUserAsync(User user, string email, string name, UserRoles userRoles, CancellationToken cancellationToken = default);
    }
}
