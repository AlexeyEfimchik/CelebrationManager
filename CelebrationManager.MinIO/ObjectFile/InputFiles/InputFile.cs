using CelebrationManager.MinIO.InputFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.MinIO.ObjectFile.InputFiles
{
    public class InputFile : IInputFile
    {
        public InputFile(string objectName, Stream file, string contentType)
        {
            ObjectName = objectName ?? throw new ArgumentNullException(nameof(objectName));
            File = file ?? throw new ArgumentNullException(nameof(file));
            ContentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
        }

        public string ObjectName { get; set; }
        public Stream File { get; set; }
        public string ContentType { get; set; }
    }
}
