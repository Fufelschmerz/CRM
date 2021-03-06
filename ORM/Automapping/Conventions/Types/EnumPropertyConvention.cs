using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using ORM.Automapping.Extensoins;

namespace ORM.Automapping.Conventions.Types
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
