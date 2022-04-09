namespace NHibernate.Automapping.Conventions.Constraints
{
    public class UniqueConvention : AttributePropertyConvention<UniqueAttribute>
    {
        protected override void Apply(UniqueAttribute attribute, IPropertyInstance instance)
        {
            bool isClustered = attribute.Key != null;

            string uniqueKeyName = isClustered
                ? $"{NamingConstants.UniqueClusteredKeyPrefix}_{attribute.Key}"
                : $"{NamingConstants.UniqueKeyPrefix}_{instance.Name}";

            uniqueKeyName = uniqueKeyName.Truncate();

            instance.UniqueKey(uniqueKeyName);
        }
    }
}
