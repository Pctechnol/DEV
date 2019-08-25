using InsightConsulting.EF.Mappings.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration;

namespace InsightConsulting.EF.Mappings.Entities
{
    public abstract class EntityMapping<T> : EntityTypeConfiguration<T>, IMappingConfig where T : class
    {
        public abstract override void Configure(EntityTypeBuilder<T> builder);

        public void Register(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<T>());
        }
    }
}
