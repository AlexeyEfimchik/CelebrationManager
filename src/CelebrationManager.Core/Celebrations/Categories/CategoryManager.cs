using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IRepository<Category, int> _repository;
        public CategoryManager(IRepository<Category, int> repository)
        {
            _repository = repository;
        }

        public async Task<IList<Category>> GetExistsCategories(IList<Category> categories)
        {
            for (int i = 0; i < categories.Count; i++)
            {
                Category category = await _repository.FirstOrDefaultAsync(c => c.Name == categories[i].Name);
                
                if (category != null)
                {
                    categories[i] = category;
                }
            }

            return categories;
        }
    }
}
