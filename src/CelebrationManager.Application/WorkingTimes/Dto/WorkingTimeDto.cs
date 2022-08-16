using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CelebrationManager.Celebrations.WorkingTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.WorkingTimes.Dto
{
    [AutoMapTo(typeof(WorkingTime))]
    public class WorkingTimeDto : EntityDto
    {
        public int Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
