using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CelebrationManager.Celebrations.EventTimes;

namespace CelebrationManager.EventTimes.Dto
{
    public class EventTimeMapProfile : Profile
    {
        public EventTimeMapProfile()
        {
            CreateMap<EventTime, EventTimeDto>();
        }
    }
}
