using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CelebrationManager.Configuration.Dto;

namespace CelebrationManager.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CelebrationManagerAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
