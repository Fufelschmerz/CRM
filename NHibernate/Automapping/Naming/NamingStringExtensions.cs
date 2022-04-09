using System;

namespace CRM.Persistence.NHibernate.AutoMapping.Naming
{
    public static class NamingStringExtensions
    {
        private const int KeyNameMaxLength = 64;

        public static string Truncate(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value.Length <= KeyNameMaxLength)
                return value;

            return value.Substring(0, KeyNameMaxLength);
        }
    }
}
