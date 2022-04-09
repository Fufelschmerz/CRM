namespace NHibernate.Automapping.Conventions.Relations
{
    public class JoinedSubclassConvention : IJoinedSubclassConvention
    {
        public void Apply(IJoinedSubclassInstance instance)
        {
            string subclassField =
                $"{instance.EntityType.Name}_{instance.Type.NonAbstractBaseType().Name}{NamingConstants.IdName}";
            string classField = $"{instance.Type.NonAbstractBaseType().Name}_{NamingConstants.IdName}";

            string foreignKeyName = $"{NamingConstants.ForeignKeyPrefix}_{subclassField}_{classField}".Truncate();

            instance.Key.ForeignKey(foreignKeyName);
        }
    }
}
