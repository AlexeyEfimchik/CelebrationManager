using Abp.Domain.Repositories;
using CelebrationManager.Celebrations.Categories;
using CelebrationManager.Celebrations.EventTimes;
using CelebrationManager.Celebrations.Files;
using CelebrationManager.Celebrations.WorkingTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations
{
    public class CelebrationManager : ICelebrationManager
    {
        public ICategoryManager CategoryManager { get; set; }
        public IWorkingTimeManager WorkingTimeManager { get; set; }
        public IEventTimeManager EventTimeManager { get; set; }
        public IRepository<CelebrationCategory, int> CelebrationCategoryRepository { get; set; }
        public IRepository<CelebrationWorkingTime, int> CelebrationWorkingTimeRepository { get; set; }
        public IRepository<File, int> FileRepository { get; set; }

        public CelebrationManager(
            ICategoryManager categoryManager,
            IWorkingTimeManager workingTimeManager,
            IEventTimeManager eventTimeManager,
            IRepository<CelebrationCategory, int> celebrationCategoryRepository,
            IRepository<CelebrationWorkingTime, int> celebrationWorkingTimeRepository,
            IRepository<File, int> fileRepository)
        {
            CategoryManager = categoryManager;
            WorkingTimeManager = workingTimeManager;
            EventTimeManager = eventTimeManager;
            CelebrationCategoryRepository = celebrationCategoryRepository;
            CelebrationWorkingTimeRepository = celebrationWorkingTimeRepository;
            FileRepository = fileRepository;
        }
    }
}
