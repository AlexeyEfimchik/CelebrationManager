using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CelebrationManager.Configuration;

namespace CelebrationManager.Web.Host.Startup
{
    [DependsOn(
       typeof(CelebrationManagerWebCoreModule))]
    public class CelebrationManagerWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CelebrationManagerWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CelebrationManagerWebHostModule).GetAssembly());
        }
    }
}
