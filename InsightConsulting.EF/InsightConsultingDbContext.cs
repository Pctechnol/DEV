using InsightConsulting.Domain.Entities;
using InsightConsulting.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace InsightConsulting.EF
{
    public class InsightConsultingDbContext : DbContext, IDomainQueryProvider
    {
        public DbSet<Users> Users { get; set; }

        public InsightConsultingDbContext(DbContextOptions<InsightConsultingDbContext> options)
          : base(options)
        {
            InstanceId = Guid.NewGuid();
        }

        #region Properties

        public Guid InstanceId { get; private set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public IQueryable<Users> UsersQuery => Users.AsNoTracking();

    }
}
