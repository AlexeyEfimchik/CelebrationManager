using System.Threading.Tasks;
using Abp.Application.Services;
using CelebrationManager.Authorization.Accounts.Dto;

namespace CelebrationManager.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
