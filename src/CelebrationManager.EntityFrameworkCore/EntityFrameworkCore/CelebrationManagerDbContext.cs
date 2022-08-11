using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CelebrationManager.Authorization.Roles;
using CelebrationManager.Authorization.Users;
using CelebrationManager.MultiTenancy;

namespace CelebrationManager.EntityFrameworkCore
{
    public class CelebrationManagerDbContext : AbpZeroDbContext<Tenant, Role, User, CelebrationManagerDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CelebrationManagerDbContext(DbContextOptions<CelebrationManagerDbContext> options)
            : base(options)
        {
        }
    }
}
