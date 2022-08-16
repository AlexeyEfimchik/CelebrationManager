using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.EventTimes
{
    public class EventTime : FullAuditedEntity
    {
        public virtual DateTime StartEvent { get; set; }
        public virtual DateTime EndEvent { get; set; }
        public IList<Celebration> Celebrations { get; set; }

        public EventTime()
        {
            Celebrations = new List<Celebration>();
        }
    }
}
