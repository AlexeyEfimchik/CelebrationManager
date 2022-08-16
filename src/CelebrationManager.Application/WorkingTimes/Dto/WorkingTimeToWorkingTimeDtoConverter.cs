using AutoMapper;
using CelebrationManager.Celebrations.WorkingTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.WorkingTimes.Dto
{
    public class WorkingTimeToWorkingTimeDtoConverter : ITypeConverter<WorkingTime, WorkingTimeDto>
    {
        private string ConvertTimeSpan(TimeSpan value)
        {
            return value.ToString();
        }

        public WorkingTimeDto Convert(WorkingTime source, WorkingTimeDto destination, ResolutionContext context)
        {
            destination = new WorkingTimeDto();

            if (source == null)
                return destination;

            destination.Id = source.Id;
            destination.Day = source.Day;
            destination.StartTime = ConvertTimeSpan(source.StartTime);
            destination.EndTime = ConvertTimeSpan(source.EndTime);

            return destination;
        }
    }
}
