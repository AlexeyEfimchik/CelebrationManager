using Abp.Application.Services.Dto;

namespace CelebrationManager.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

