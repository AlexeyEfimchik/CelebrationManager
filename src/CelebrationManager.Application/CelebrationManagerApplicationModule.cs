using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CelebrationManager.Authorization;

namespace CelebrationManager
{
    [DependsOn(
        typeof(CelebrationManagerCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CelebrationManagerApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CelebrationManagerAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CelebrationManagerApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
