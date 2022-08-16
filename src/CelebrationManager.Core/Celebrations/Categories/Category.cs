using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.Categories
{
    public class Category : FullAuditedEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public IList<CelebrationCategory> CelebrationsCategoty { get; set; }

        public Category()
        {
            CelebrationsCategoty = new List<CelebrationCategory>();
        }
    }
}
