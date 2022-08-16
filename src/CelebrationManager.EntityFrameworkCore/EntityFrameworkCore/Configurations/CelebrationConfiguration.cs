using CelebrationManager.Celebrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.EntityFrameworkCore.Configurations
{
    public class CelebrationConfiguration : IEntityTypeConfiguration<Celebration>
    {
        public void Configure(EntityTypeBuilder<Celebration> builder)
        {
            builder.ToTable("Celebrations");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseHiLo("celebrationsSeq");

            builder.HasOne(o => o.EventTime)
                .WithMany(o => o.Celebrations)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Files)
                .WithOne(o => o.Celebration)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.Header).IsRequired();
            builder.Property(o => o.Description).IsRequired();

            builder.Ignore(b => b.Files);
        }
    }
}
