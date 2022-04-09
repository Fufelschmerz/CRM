namespace DataAnnotations
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class LengthAttribute : Attribute
    {
        public LengthAttribute(int length)
        {
            Length = length;
        }

        public int Length { get; }
    }
}
