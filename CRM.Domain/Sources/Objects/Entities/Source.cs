namespace CRM.Domain.Sources.Objects.Entities
{
    using global::Domain.Abstracions.Entities;
    using System;

    public class Source : IEntity
    {
        [Obsolete("Constructor is only for reflection")]
        public Source()
        {

        }

        public Source(string name)
        {
            CreateOrEditSource(name);
        }

        public virtual long Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual bool IsArchive { get; protected set; } = false;

        protected internal virtual void CreateOrEditSource(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }

        public virtual void AddSourceToArchive()
        {
            IsArchive = true;
        }

        public virtual void DeleteSourceToArchive()
        {
            IsArchive = false;
        }
    }
}
