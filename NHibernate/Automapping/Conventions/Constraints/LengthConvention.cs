namespace NHibernate.Automapping.Conventions.Constraints
{
    public class LengthConvention : AttributePropertyConvention<LengthAttribute>
    {
        protected override void Apply(LengthAttribute attribute, IPropertyInstance instance)
        {
            instance.Length(attribute.Length);
        }
    }
}
