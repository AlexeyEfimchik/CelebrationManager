using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace CelebrationManager.Authorization
{
    public class CelebrationManagerAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Celebrations, L("Celebrations"));
            context.CreatePermission(PermissionNames.Pages_Categories, L("Categories"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CelebrationManagerConsts.LocalizationSourceName);
        }
    }
}
