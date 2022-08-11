using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CelebrationManager.Controllers
{
    public abstract class CelebrationManagerControllerBase: AbpController
    {
        protected CelebrationManagerControllerBase()
        {
            LocalizationSourceName = CelebrationManagerConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
