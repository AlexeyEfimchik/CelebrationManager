using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CelebrationManager.Authorization.Roles;
using CelebrationManager.Authorization.Users;
using CelebrationManager.MultiTenancy;
using CelebrationManager.Celebrations.Categories;
using CelebrationManager.Celebrations.EventTimes;
using CelebrationManager.Celebrations.WorkingTimes;
using CelebrationManager.EntityFrameworkCore.Configurations;
using CelebrationManager.Celebrations;
using CelebrationManager.Celebrations.Files;

namespace CelebrationManager.EntityFrameworkCore
{
    public class CelebrationManagerDbContext : AbpZeroDbContext<Tenant, Role, User, CelebrationManagerDbContext>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<EventTime> EventTimes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<Celebration> Celebrations { get; set; }
        public DbSet<CelebrationWorkingTime> CelebrationsWorkingTime { get; set; }
        public DbSet<CelebrationCategory> CelebrationsCategory { get; set; }

        public CelebrationManagerDbContext(DbContextOptions<CelebrationManagerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CelebrationConfiguration());
            modelBuilder.ApplyConfiguration(new EventTimeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingTimeConfiguration());
            modelBuilder.ApplyConfiguration(new CelebrationCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CelebrationWorkingTimeConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
        }
    }
}
