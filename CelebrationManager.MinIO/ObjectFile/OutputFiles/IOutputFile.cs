using CelebrationManager.MinIO.ObjectFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.MinIO.OutputFiles
{
    public interface IOutputFile : IFile
    {
        public Stream File { get; set; }
    }
}
