using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using CelebrationManager.Authorization;
using CelebrationManager.Categories.Dto;
using CelebrationManager.Celebrations.Categories;
using CelebrationManager.Celebrations.Dto;
using CelebrationManager.Celebrations.EventTimes;
using CelebrationManager.Celebrations.Files;
using CelebrationManager.Celebrations.WorkingTimes;
using CelebrationManager.MinIO;
using CelebrationManager.MinIO.InputFiles;
using CelebrationManager.MinIO.ObjectFile.InputFiles;
using CelebrationManager.WorkingTimes.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations
{
    [AbpAuthorize(PermissionNames.Pages_Celebrations)]
    public class CelebrationAppService : AsyncCrudAppService<Celebration, CelebrationDto, int, PagedCelebrationResultRequestDto, CreateCelebrationDto, CelebrationDto>, ICelebrationAppService
    {
        private readonly ICelebrationManager _celebrationManager;
        private readonly IFileStorage _fileStorage;

        public CelebrationAppService(IRepository<Celebration, int> repository,
                                     ICelebrationManager celebrationManager,
                                     IFileStorage fileStorage) 
            : base(repository) 
        {
            _celebrationManager = celebrationManager;
            _fileStorage = fileStorage;
        }

        private async Task<EventTime> GetExistingEventTimeOrDefault(EventTime eventTime)
        {
            return await _celebrationManager.EventTimeManager.GetEventTimeOrDefault(eventTime) ?? eventTime;
        }

        private async Task<IList<WorkingTime>> MapExistsWorkingTimes(IList<WorkingTimeDto> workingTimes)
        {
            var listWorkingTimes = ObjectMapper.Map<IList<WorkingTime>>(workingTimes);
            return await _celebrationManager.WorkingTimeManager.GetExistsWorkingTimes(listWorkingTimes);
        }

        private void SetWorkingTimesToCelebration(Celebration celebration, IList<WorkingTime> workingTimes)
        {
            celebration.CelebrationsWorkingTime.Clear();

            for(int i = 0; i < workingTimes.Count; i++)
            {
                celebration.CelebrationsWorkingTime.Add(new CelebrationWorkingTime() { Celebration = celebration, WorkingTime = workingTimes[i] });
            }
        }

        private async Task<IList<Category>> MapExistsCategories(IList<CategoryDto> categories)
        {
            var listCategories = ObjectMapper.Map<IList<Category>>(categories);
            return await _celebrationManager.CategoryManager.GetExistsCategories(listCategories);
        }

        private void SetCategoriesToCelebration(Celebration celebration, IList<Category> categories)
        {
            celebration.CelebrationsCategoty.Clear();

            for (int i = 0; i < categories.Count; i++)
            {
                celebration.CelebrationsCategoty.Add(new CelebrationCategory() { Celebration = celebration, Category = categories[i] });
            }
        }

        private async Task SaveFiles(IList<IFormFile> files, Celebration celebration)
        {

            foreach (var file in files)
            {
                InputFile fileStorage = new InputFile(file.FileName.GetHashCode().ToString(), file.OpenReadStream(), file.ContentType);

                await _fileStorage.SaveFile(fileStorage);
                await _celebrationManager.FileRepository.InsertAsync(new File() { Name = fileStorage.ObjectName, Celebration = celebration});
            }
        }

        public override async Task<CelebrationDto> CreateAsync([FromForm] CreateCelebrationDto input)
        {
            CheckCreatePermission();

            var celebration = ObjectMapper.Map<Celebration>(input);

            celebration.EventTime = await GetExistingEventTimeOrDefault(celebration.EventTime);

            var wokingTimes = await MapExistsWorkingTimes(input.WorkingTimes);
            SetWorkingTimesToCelebration(celebration, wokingTimes);

            var categories = await MapExistsCategories(input.Categories);
            SetCategoriesToCelebration(celebration, categories);

            await Repository.InsertAsync(celebration);

            await SaveFiles(input.Files, celebration);

            var celebrationDto = ObjectMapper.Map<CelebrationDto>(celebration);
            celebrationDto.Files = input.Files;

            return celebrationDto;
        }

        private async Task RemoveOldData(Celebration celebration)
        {
            var currentFiles = _celebrationManager.FileRepository.GetAll()
                .Where(x => x.Celebration.Id == celebration.Id)
                .Select(x => x.Name).ToList();

            if(currentFiles.Count > 0)
            {
                await _fileStorage.RemoveListFiles(currentFiles);
            }

            await _celebrationManager.CelebrationCategoryRepository.DeleteAsync(x => x.CelebrationId == celebration.Id);
            await _celebrationManager.CelebrationWorkingTimeRepository.DeleteAsync(x => x.CelebrationId == celebration.Id);
            await _celebrationManager.FileRepository.HardDeleteAsync(x => x.Celebration.Id == celebration.Id);
        }

        public override async Task<CelebrationDto> UpdateAsync([FromForm] CelebrationDto input)
        {
            CheckUpdatePermission();

            var celebration = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, celebration);

            await RemoveOldData(celebration);

            celebration.EventTime = await GetExistingEventTimeOrDefault(celebration.EventTime);

            var wokingTimes = await MapExistsWorkingTimes(input.WorkingTimes);
            SetWorkingTimesToCelebration(celebration, wokingTimes);

            var categories = await MapExistsCategories(input.Categories);
            SetCategoriesToCelebration(celebration, categories);

            await Repository.UpdateAsync(celebration);

            await SaveFiles(input.Files, celebration);

            var celebrationDto = ObjectMapper.Map<CelebrationDto>(celebration);
            celebrationDto.Files = input.Files;

            return celebrationDto;
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var celebration = await Repository.GetAsync(input.Id);

            await RemoveOldData(celebration);

            await Repository.DeleteAsync(celebration);
        }

        public override async Task<CelebrationDto> GetAsync(EntityDto<int> input)
        {
            CheckGetPermission();

            var celebration = await Repository.GetAsync(input.Id);

            return ObjectMapper.Map<CelebrationDto>(celebration);
        }


        public async Task<ListResultDto<CelebrationDto>> GetAllCelebrations()
        {
            CheckGetAllPermission();

            var celebrations = await Repository.GetAllListAsync();

            return await Task.FromResult(new ListResultDto<CelebrationDto>(
                ObjectMapper.Map<List<CelebrationDto>>(celebrations).OrderBy(p => p.Header).ToList()
            ));
        }
    }
}
