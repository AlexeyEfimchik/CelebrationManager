using Abp.Dependency;
using CelebrationManager.MinIO.InputFiles;
using CelebrationManager.MinIO.ObjectFile;
using CelebrationManager.MinIO.OutputFiles;
using Minio;

namespace CelebrationManager.MinIO.Configurations
{
    public interface IMinIOConfiguration : ITransientDependency
    {
        public PutObjectArgs GetPutObjectArgs(string bucket, IInputFile file);
        public GetObjectArgs GetGetObjectsArgs(string bucket, IOutputFile file, Action<Stream> callBack);
        public MinioClient GetMinIOClient(string endpoint, string accessKey, string secretKey);
        public RemoveObjectsArgs GetRemoveObjectsArgs(string bucket, List<string> fileList);
    }
}
