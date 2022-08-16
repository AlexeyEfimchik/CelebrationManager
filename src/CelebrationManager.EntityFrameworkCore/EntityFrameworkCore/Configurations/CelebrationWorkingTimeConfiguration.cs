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
    public class CelebrationWorkingTimeConfiguration : IEntityTypeConfiguration<CelebrationWorkingTime>
    {
        public void Configure(EntityTypeBuilder<CelebrationWorkingTime> builder)
        {
            builder.HasKey(x => new { x.WorkingTimeId, x.CelebrationId });
        }
    }
}
