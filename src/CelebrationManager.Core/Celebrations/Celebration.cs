using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CelebrationManager.Celebrations.Categories;
using CelebrationManager.Celebrations.EventTimes;
using CelebrationManager.Celebrations.Files;
using CelebrationManager.Celebrations.WorkingTimes;
using System;
using System.Collections.Generic;

namespace CelebrationManager.Celebrations
{
    public class Celebration : FullAuditedAggregateRoot
    {
        public virtual string Header { get; set; }
        public virtual string Description { get; set; }
        public virtual EventTime EventTime { get; set; }
        public IList<CelebrationCategory> CelebrationsCategoty { get; set; }
        public IList<CelebrationWorkingTime> CelebrationsWorkingTime { get; set; }
        public IList<File> Files { get; set; }

        public Celebration()
        {
            CelebrationsCategoty = new List<CelebrationCategory>();
            CelebrationsWorkingTime = new List<CelebrationWorkingTime>();
            Files = new List<File>();
        }
    }
}
