using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using CelebrationManager.Celebrations.Categories;
using CelebrationManager.Celebrations.EventTimes;
using CelebrationManager.Celebrations.WorkingTimes;
using CelebrationManager.Celebrations.Files;

namespace CelebrationManager.Celebrations
{
    public interface ICelebrationManager : ITransientDependency
    {
        public ICategoryManager CategoryManager { get; set; }
        public IWorkingTimeManager WorkingTimeManager { get; set; }
        public IEventTimeManager EventTimeManager { get; set; }
        public IRepository<CelebrationCategory, int> CelebrationCategoryRepository { get; set; }
        public IRepository<CelebrationWorkingTime, int> CelebrationWorkingTimeRepository { get; set; }
        public IRepository<File, int> FileRepository { get; set; }
    }
}
