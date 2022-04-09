using System;

namespace NHibernate.Automapping.Extensoins
{
    public static class MemberAttributesExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Member member)
            where TAttribute : Attribute
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            return member.MemberInfo.GetCustomAttribute<TAttribute>();
        }

        public static bool HasAttribute<TAttribute>(this Member member)
            where TAttribute : Attribute
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            return member.GetAttribute<TAttribute>() != null;
        }
    }
}
