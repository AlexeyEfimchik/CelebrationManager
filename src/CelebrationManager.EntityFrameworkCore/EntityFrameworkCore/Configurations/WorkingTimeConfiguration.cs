using CelebrationManager.Celebrations.WorkingTimes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.EntityFrameworkCore.Configurations
{
    public class WorkingTimeConfiguration : IEntityTypeConfiguration<WorkingTime>
    {
        public void Configure(EntityTypeBuilder<WorkingTime> builder)
        {
            builder.ToTable("WorkingTimes");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseHiLo("workingTimesSeq");

            builder.Property(o => o.StartTime).IsRequired();
            builder.Property(o => o.EndTime).IsRequired();
            builder.Property(o => o.Day).IsRequired();
        }
    }
}
