namespace CRM.Domain.States.Objects.Entities
{
    using Enums;
    using global::Domain.Abstracions.Entities;
    using System;
    public class State : IEntity
    {
        [Obsolete("Constructor is only for reflection")]
        public State()
        {

        }

        public State(string name, StatusState status)
        {
            CreateOrEditState(name, status);
        }

        public virtual long Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual StatusState Status { get; protected set; }

        public virtual bool IsArchive { get; protected set; } = false;

        protected internal virtual void CreateOrEditState(string name, StatusState status)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(status));

            Name = name;
            Status = status;
        }

        public virtual void AddStateToArchive()
        {
            IsArchive = true;
        }

        public virtual void DeleteStateToArchive()
        {
            IsArchive = false;
        }
    }
}
