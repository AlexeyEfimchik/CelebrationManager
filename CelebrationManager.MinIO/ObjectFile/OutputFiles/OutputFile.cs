using CelebrationManager.MinIO.OutputFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.MinIO.ObjectFile.OutputFiles
{
    public class OutputFile : IOutputFile
    {
        public OutputFile(string objectName)
        {
            ObjectName = objectName ?? throw new ArgumentNullException(nameof(objectName));
            File = new MemoryStream();
        }
        public string ObjectName { get; set; }
        public Stream File { get; set; }
    }
}
