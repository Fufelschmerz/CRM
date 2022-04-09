using System;

namespace NHibernate.Automapping.Conventions.Types
{
    public class EnumPropertyConvention : IPropertyConventionAcceptance, IPropertyConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Any(
                subcriteria => subcriteria.Expect(
                    inspector => inspector.Property.PropertyType.IsEnum),
                subcriteria => subcriteria.Expect(
                    inspector => inspector.Property.PropertyType.IsNullable() &&
                                 Nullable.GetUnderlyingType(inspector.Property.PropertyType).IsEnum));
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType(instance.Property.PropertyType);
        }
    }
}
