using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using ORM.Automapping.Extensoins;

namespace ORM.Automapping.Conventions
{
    public class IdConvention : IIdConventionAcceptance, IIdConvention
    {
        private static readonly Type[] NativeGeneratedTypes =
        {
            typeof(sbyte),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(byte),
            typeof(ushort),
            typeof(uint),
            typeof(ulong),
        };



        public void Accept(IAcceptanceCriteria<IIdentityInspector> criteria)
        {
            criteria.Expect(inspector => inspector.Property.IsOfType(NativeGeneratedTypes));
        }

        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Native();
        }

    }
}
