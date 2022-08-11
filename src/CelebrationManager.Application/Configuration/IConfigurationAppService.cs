using System.Threading.Tasks;
using CelebrationManager.Configuration.Dto;

namespace CelebrationManager.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
