using Microsoft.EntityFrameworkCore;

namespace InsightConsulting.EF.Mappings.Interfaces
{
    public interface IMappingConfig
    {
        void Register(ModelBuilder modelBuilder);
    }
}
