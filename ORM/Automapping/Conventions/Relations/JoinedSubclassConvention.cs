using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using ORM.Automapping.Extensoins;
using ORM.Automapping.Naming;

namespace ORM.Automapping.Conventions.Relations
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
