using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.Categories
{
    public interface ICategoryManager : ITransientDependency
    {
        public Task<IList<Category>> GetExistsCategories(IList<Category> categories);
    }
}
