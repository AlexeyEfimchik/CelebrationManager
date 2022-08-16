using AutoMapper;
using CelebrationManager.Celebrations.WorkingTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.WorkingTimes.Dto
{
    public class WorkingTimeDtoToWorkingTimeConverter : ITypeConverter<WorkingTimeDto, WorkingTime>
    {
        private TimeSpan ConvertTimeSpan(string value)
        {
            if (!TimeSpan.TryParse(value, out TimeSpan time))
            {
                throw new FormatException("The value does not match the TimeSpan format");
            }

            return time;
        }

        public WorkingTime Convert(WorkingTimeDto source, WorkingTime destination, ResolutionContext context)
        {
            destination = new WorkingTime();

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
