using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CelebrationManager.Celebrations.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations
{
    public interface ICelebrationAppService: IAsyncCrudAppService<CelebrationDto, int, PagedCelebrationResultRequestDto, CreateCelebrationDto, CelebrationDto>
    {
        public Task<ListResultDto<CelebrationDto>> GetAllCelebrations();
    }
}
