using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CelebrationManager.EntityFrameworkCore;
using CelebrationManager.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CelebrationManager.Web.Tests
{
    [DependsOn(
        typeof(CelebrationManagerWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class CelebrationManagerWebTestModule : AbpModule
    {
        public CelebrationManagerWebTestModule(CelebrationManagerEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CelebrationManagerWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(CelebrationManagerWebMvcModule).Assembly);
        }
    }
}