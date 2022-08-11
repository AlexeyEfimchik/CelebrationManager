using Abp.Authorization;
using CelebrationManager.Authorization.Roles;
using CelebrationManager.Authorization.Users;

namespace CelebrationManager.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
