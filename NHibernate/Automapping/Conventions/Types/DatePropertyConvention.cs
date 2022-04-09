using System;
using Microsoft.VisualBasic.CompilerServices;

namespace NHibernate.Automapping.Conventions.Types
{
    public class DatePropertyConvention : IPropertyConventionAcceptance, IPropertyConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria
                .Expect(inspector => inspector.Property.IsOfType<DateTime, DateTime?>())
                .Any(
                    x => x.Expect(inspector => inspector.Property.Name.EndsWith("Date")));
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType<DateType>();
        }
    }
}
