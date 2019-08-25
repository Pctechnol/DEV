using InsightConsulting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsightConsulting.EF.Mappings.Entities
{
    public class UserMapping : EntityMapping<Users>
    {
        public override void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();
        }
    }
}
