namespace Domain.Base
{
    using Domain.Abstracions.ValueObjects;

    public abstract class ValueObject : IValueObject
    {
        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}
