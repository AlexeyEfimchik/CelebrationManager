using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;

namespace CelebrationManager.Celebrations.WorkingTimes
{
    public interface IWorkingTimeManager : ITransientDependency
    {
        public Task<IList<WorkingTime>> GetExistsWorkingTimes(IList<WorkingTime> workingTimes);
    }
}
