using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.WorkingTimes
{
    public class WorkingTime : FullAuditedEntity
    {
        public virtual int Day { get; set; }
        public virtual TimeSpan StartTime { get; set; }
        public virtual TimeSpan EndTime { get; set; }

        public IList<Celebration> Celebrations;

        public WorkingTime()
        {
            Celebrations = new List<Celebration>();
        }
    }
}
