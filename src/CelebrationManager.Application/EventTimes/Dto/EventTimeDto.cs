using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CelebrationManager.Celebrations.EventTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.EventTimes.Dto
{
    [AutoMapTo(typeof(EventTime))]
    public class EventTimeDto : EntityDto
    {
        public DateTime StartEvent { get; set; }
        public DateTime EndEvent { get; set; }
    }
}
