using CelebrationManager.Celebrations.Files;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.EntityFrameworkCore.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("Files");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseHiLo("filesSeq");


            builder.Property(o => o.Name).IsRequired();
        }
    }
}
