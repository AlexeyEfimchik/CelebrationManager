using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.Files
{
    public class File : FullAuditedEntity
    {
        public string Name { get; set; }

        public Celebration Celebration { get; set; }
    }
}
