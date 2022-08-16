using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.Categories
{
    public class CelebrationCategory : Entity
    {
        public int CelebrationId { get; set; }
        public int CategoryId { get; set; }

        public Celebration Celebration { get; set; }
        public Category Category { get; set; }
    }
}
