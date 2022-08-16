using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;

namespace CelebrationManager.Celebrations.EventTimes
{
    public interface IEventTimeManager : ITransientDependency
    {
        public Task<EventTime> GetEventTimeOrDefault(EventTime eventTime);
    }
}
