using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CelebrationManager.EntityFrameworkCore
{
    public static class CelebrationManagerDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CelebrationManagerDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CelebrationManagerDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
