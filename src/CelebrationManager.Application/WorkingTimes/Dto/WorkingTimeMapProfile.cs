using AutoMapper;
using CelebrationManager.Celebrations.WorkingTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.WorkingTimes.Dto
{
    public class WorkingTimeMapProfile : Profile
    {
        public WorkingTimeMapProfile()
        {
            CreateMap<WorkingTimeDto, WorkingTime>().ConvertUsing(new WorkingTimeDtoToWorkingTimeConverter());
            CreateMap<WorkingTime, WorkingTimeDto>().ConvertUsing(new WorkingTimeToWorkingTimeDtoConverter());
        }
    }
}
