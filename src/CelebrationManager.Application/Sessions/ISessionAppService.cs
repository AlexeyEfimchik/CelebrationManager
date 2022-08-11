using System.Threading.Tasks;
using Abp.Application.Services;
using CelebrationManager.Sessions.Dto;

namespace CelebrationManager.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
