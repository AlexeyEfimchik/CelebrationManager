using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace CelebrationManager.Celebrations.EventTimes
{
    public class EventTimeManager : IEventTimeManager
    {
        private readonly IRepository<EventTime, int> _repository;
        public EventTimeManager(IRepository<EventTime, int> repository)
        {
            _repository = repository;
        }

        public async Task<EventTime> GetEventTimeOrDefault(EventTime eventTime)
        {
            return await _repository.FirstOrDefaultAsync(e =>
                e.StartEvent == eventTime.StartEvent && e.EndEvent == eventTime.EndEvent);
        }
    }
}
