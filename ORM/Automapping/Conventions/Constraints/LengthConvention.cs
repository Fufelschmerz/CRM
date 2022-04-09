using DataAnnotations;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ORM.Automapping.Conventions.Constraints
{
    public class LengthConvention : AttributePropertyConvention<LengthAttribute>
    {
        protected override void Apply(LengthAttribute attribute, IPropertyInstance instance)
        {
            instance.Length(attribute.Length);
        }
    }
}
