namespace CRM.Domain.Users.Services
{
    using Criteria;
    using Commands.Absctractions.Builders;
    using CRM.Domain.Common.Commands.Extensions;
    using Enums;
    using Exceptions;
    using Objects.Entities;
    using Abstractions;
    using Queries.Abstractions.Builders;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        
        private readonly IAsyncCommandBuilder _commandBuilder;

        public UserService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ??
                throw new ArgumentNullException(nameof(queryBuilder));

            _commandBuilder = commandBuilder ??
                throw new ArgumentNullException(nameof(commandBuilder));
        }


        public async Task<User> CreateUserAsync(string email, string name, string password, UserRoles userRole, CancellationToken cancellationToken = default)
        {
            await CheckUserByEmailAsync(email, cancellationToken);

            var user = new User(email, name, password, userRole);

            await _commandBuilder.CreateAsync(user, cancellationToken);

            return user;
        }

        public async Task DeleteUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await _commandBuilder.DeleteAsync(user, cancellationToken);
        }

        public async Task EditUserAsync(User user, string email, string name, UserRoles userRoles, CancellationToken cancellationToken = default)
        {
            await CheckUserByEmailAsync(email, cancellationToken, user);
            user.CreateOrEditUser(email, name, userRoles);
        }

        private async Task CheckUserByEmailAsync(string email, CancellationToken cancellationToken = default, User editUser = null)
        {
            var user = await _queryBuilder.For<User>()
                .WithAsync(new FindUserByEmail(email), cancellationToken);

            if(user != null && !user.Equals(editUser))
                throw new UserAlreadyExistsException("A user with this e-mail already exists");
        }
    }
}
