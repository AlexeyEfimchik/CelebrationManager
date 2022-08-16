using Abp.Dependency;
using CelebrationManager.MinIO.InputFiles;
using CelebrationManager.MinIO.OutputFiles;


namespace CelebrationManager.MinIO
{
    public interface IFileStorage : ITransientDependency
    {
        public Task RemoveListFiles(List<string> files);
        public Task SaveFile(IInputFile file);
        public Task<IOutputFile> GetFile(IInputFile file);
    }
}
