using CelebrationManager.Celebrations.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.EntityFrameworkCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseHiLo("categoriesSeq");

            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.Description).IsRequired();
        }
    }
}
