using System;
using CRM.Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using ORM.Automapping.Configutation;
using ORM.Automapping.Conventions;

namespace CRM.Persistence.NHibernate
{
    public class NHibernateInitializer
    {
        private readonly string _connectionString;

        public NHibernateInitializer(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException(nameof(connectionString));

            _connectionString = connectionString;
        }

        private static bool ShouldExpose = false;

        private IPersistenceConfigurer GetDatabaseConfiguration() =>
            MySQLConfiguration
                .Standard
                .Dialect<MySQL57Dialect>()
                .ConnectionString(_connectionString);

        private void Expose(Configuration configuration)
        {
            if (ShouldExpose)
            {
#if DEBUG
                new SchemaUpdate(configuration).Execute(true, true);
#endif
            }
        }

        private AutoPersistenceModel GetAutoPersistenceModel() =>
            AutoMap.AssemblyOf<DomainAssemblyMarker>(new DomainAutoMappingConfiguration())
            .Conventions.AddFromAssemblyOf<IdConvention>()
            .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never())
            .UseOverridesFromAssemblyOf<NHibernateInitializer>();

        public Configuration GetConfiguration()
        {
            return Fluently.Configure()
                .Database(GetDatabaseConfiguration)
                .Mappings(x => x.AutoMappings.Add(GetAutoPersistenceModel))
                .ExposeConfiguration(Expose)
                .BuildConfiguration();
        }
    }
}
