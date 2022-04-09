namespace CRM.Domain.Users.Objects.Entities
{
    using CRM.Domain.Users.Enums;
    using CRM.Domain.Users.Objects.ValueObjects;
    using DataAnnotations;
    using global::Domain.Abstracions.Entities;
    using System;

    public class User : IEntity
    {
        [Obsolete("Constructor is only for reflection")]
        public User() { }

        public User(string email, string name, string password, UserRoles userRole)
        {
            CreateOrEditUser(email, name, userRole);
            SetPassword(password);
        }

        public virtual long Id { get; protected set; }
        
        public virtual string Name { get; set; }

        public virtual Password Password { get; protected set; }

        public virtual UserRoles UserRole { get; protected set; }

        [Unique]
        public virtual string Email { get; protected set; }

        public virtual bool IsBlocked { get; protected set; } = false;

        protected internal virtual void CreateOrEditUser(string email, string name, UserRoles userRole)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException(nameof(email));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            Email = email;
            UserRole = userRole;
            Name = name;
        }

        public virtual void SetPassword(string password)
        {
            Password = new Password(password);
        }

        public virtual void BlockUser()
        {
            IsBlocked = true;
        }

        public virtual void UnlockUser()
        {
            IsBlocked = false;
        }
    }
}
