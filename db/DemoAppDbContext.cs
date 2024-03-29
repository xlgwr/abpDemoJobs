using Microsoft.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace demo3 {
    public class DemoAppDbContext : AbpDbContext<DemoAppDbContext> {
        public DemoAppDbContext (DbContextOptions<DemoAppDbContext> options) : base (options) {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);

            modelBuilder.ConfigureBackgroundJobs ();
        }
    }
}