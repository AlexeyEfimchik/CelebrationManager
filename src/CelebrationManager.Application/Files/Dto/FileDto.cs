using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Files.Dto
{
    [AutoMapTo(typeof(File))]
    public class FileDto
    {
        public string Name { get; set; }
    }
}
