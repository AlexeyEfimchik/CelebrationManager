using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.WorkingTimes
{
    public class CelebrationWorkingTime : Entity
    {
        public int CelebrationId { get; set; }
        public int WorkingTimeId { get; set; }

        public Celebration Celebration { get; set; }
        public WorkingTime WorkingTime { get; set; }
    }
}
