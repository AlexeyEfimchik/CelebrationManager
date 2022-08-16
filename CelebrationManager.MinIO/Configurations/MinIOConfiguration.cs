using Abp.Dependency;
using CelebrationManager.MinIO.InputFiles;
using CelebrationManager.MinIO.ObjectFile;
using CelebrationManager.MinIO.OutputFiles;
using Minio;

namespace CelebrationManager.MinIO.Configurations
{
    public class MinIOConfiguration : IMinIOConfiguration
    {
        public PutObjectArgs GetPutObjectArgs(string bucket, IInputFile file)
        {
            return new PutObjectArgs()
                    .WithBucket(bucket)
                    .WithObject(file.ObjectName)
                    .WithContentType(file.ContentType)
                    .WithObjectSize(file.File.Length)
                    .WithStreamData(file.File);
        }

        public MinioClient GetMinIOClient(string endpoint, string accessKey, string secretKey)
        {
            return new MinioClient()
                     .WithEndpoint(endpoint)
                     .WithCredentials(accessKey, secretKey)
                     .Build();
        }

        public GetObjectArgs GetGetObjectsArgs(string bucket, IOutputFile file, Action<Stream> callBack)
        {
            return new GetObjectArgs()
                .WithBucket(bucket)
                .WithObject(file.ObjectName)
                .WithCallbackStream(callBack);
        }


        public RemoveObjectsArgs GetRemoveObjectsArgs(string bucket, List<string> fileList)
        {
            return new RemoveObjectsArgs()
                .WithBucket(bucket)
                .WithObjects(fileList);
        }
    }
}
