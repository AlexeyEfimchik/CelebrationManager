using CelebrationManager.Celebrations.EventTimes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.EntityFrameworkCore.Configurations
{
    public class EventTimeConfiguration : IEntityTypeConfiguration<EventTime>
    {
        public void Configure(EntityTypeBuilder<EventTime> builder)
        {
            builder.ToTable("EventTimes");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseHiLo("eventTimesSeq");

            builder.Property(o => o.StartEvent).IsRequired();
            builder.Property(o => o.EndEvent).IsRequired();
        }
    }
}
