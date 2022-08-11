using Abp.Application.Services;
using CelebrationManager.MultiTenancy.Dto;

namespace CelebrationManager.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

