using CelebrationManager.MinIO.ObjectFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.MinIO.InputFiles
{
    public interface IInputFile : IFile
    {
        public Stream File { get; set; }
        public string ContentType { get; set; }
    }
}
