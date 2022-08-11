using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CelebrationManager.MultiTenancy;

namespace CelebrationManager.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
