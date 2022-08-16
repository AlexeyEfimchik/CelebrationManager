using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.WorkingTimes
{
    public class WorkingTimeManager : IWorkingTimeManager
    {
        private readonly IRepository<WorkingTime, int> _repository;
        public WorkingTimeManager(IRepository<WorkingTime, int> repository)
        {
            _repository = repository;
        }

        public async Task<IList<WorkingTime>> GetExistsWorkingTimes(IList<WorkingTime> workingTimes)
        {
            for(int i = 0; i < workingTimes.Count; i++)
            {
                WorkingTime workingTime = await _repository.FirstOrDefaultAsync(t => t.Day == workingTimes[i].Day &&
                                                              t.StartTime == workingTimes[i].StartTime &&
                                                              t.EndTime == workingTimes[i].EndTime);
                if(workingTime != null)
                {
                    workingTimes[i] = workingTime;
                }
            }

            return workingTimes;
        }
    }
}
