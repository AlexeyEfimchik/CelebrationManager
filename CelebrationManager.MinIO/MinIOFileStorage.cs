using CelebrationManager.MinIO.Configurations;
using CelebrationManager.MinIO.InputFiles;
using CelebrationManager.MinIO.ObjectFile.OutputFiles;
using CelebrationManager.MinIO.OutputFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.MinIO
{
    public class MinIOFileStorage : IFileStorage
    {
        private readonly MinioClient _minioClient;
        private readonly ILogger<MinIOFileStorage> _logger;
        private readonly IMinIOConfiguration _minIOConfiguration;
        private readonly string _bucket;

        public MinIOFileStorage(ILogger<MinIOFileStorage> logger, IMinIOConfiguration minIOArgs, IConfiguration configuration)
        {
            _logger = logger;
            _minIOConfiguration = minIOArgs;
            _minioClient = minIOArgs.GetMinIOClient(configuration["Minio:Endpoint"],
                                                    configuration["Minio:AccessKey"],
                                                    configuration["Minio:SecretKey"]);
            _bucket = configuration["Minio:Bucket"];
        }

        private async Task<IOutputFile> GetObject(IInputFile file)
        {
            IOutputFile outputFile = (IOutputFile) new OutputFile(file.ObjectName);

            await _minioClient.GetObjectAsync(_minIOConfiguration.GetGetObjectsArgs(_bucket, outputFile, async (stream) =>
            {
                await stream.CopyToAsync(outputFile.File);
            }));

            _logger.LogInformation($"Bucket: {_bucket}, Successfully downloaded {file.ObjectName}");

            return outputFile;
        }

        private async Task PutObject(IInputFile file)
        {
            await _minioClient.PutObjectAsync(_minIOConfiguration.GetPutObjectArgs(_bucket, file));

            _logger.LogInformation($"Bucket: {_bucket}, ContentType: {file.ContentType}, Successfully uploaded {file.ObjectName}");
        }

        public async Task RemoveListFiles(List<string> files)
        {
            await _minioClient.RemoveObjectsAsync(_minIOConfiguration.GetRemoveObjectsArgs(_bucket, files));
        }

        public async Task SaveFile(IInputFile file)
        {
            await PutObject(file);
        }

        public async Task<IOutputFile> GetFile(IInputFile file)
        {
            return await GetObject(file);
        }
    }
}
