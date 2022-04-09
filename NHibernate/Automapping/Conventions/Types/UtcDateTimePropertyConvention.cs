using System;

namespace NHibernate.Automapping.Conventions.Types
{
    public class UtcDateTimePropertyConvention : IPropertyConventionAcceptance, IPropertyConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria
                .Expect(inspector => inspector.Property.IsOfType<DateTime, DateTime?>())
                .Any(
                    subcriteria => subcriteria.Expect(inspector => inspector.Property.Name.EndsWith("Utc")));
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType<UtcDateTimeType>();
        }
    }
}
