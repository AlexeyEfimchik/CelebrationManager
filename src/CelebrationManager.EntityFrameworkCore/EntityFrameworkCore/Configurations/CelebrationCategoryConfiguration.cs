using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelebrationManager.Celebrations.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelebrationManager.EntityFrameworkCore.Configurations
{
    public class CelebrationCategoryConfiguration : IEntityTypeConfiguration<CelebrationCategory>
    {
        public void Configure(EntityTypeBuilder<CelebrationCategory> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.CelebrationId });
        }
    }
}
