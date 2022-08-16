using AutoMapper;
using CelebrationManager.Celebrations.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationManager.Celebrations.Dto
{
    public class CelebrationMapProfile : Profile
    {
        public CelebrationMapProfile()
        {
            CreateMap<CelebrationDto, Celebration>()
                .ForMember(x => x.Files, opt => opt.MapFrom(x => x.Files))
                .ForMember(x => x.CelebrationsWorkingTime, opt => opt.Ignore())
                .ForMember(x => x.Files, opt => opt.MapFrom(x => x.Files));

            CreateMap<CreateCelebrationDto, Celebration>()
                .ForMember(x => x.CelebrationsCategoty, opt => opt.Ignore())
                .ForMember(x => x.CelebrationsWorkingTime, opt => opt.Ignore())
                .ForMember(x => x.Files, opt => opt.MapFrom(x => x.Files));

            CreateMap<Celebration, CelebrationDto>()
                .ForMember(x => x.Files, opt => opt.Ignore())
                .ForMember(x => x.Categories, opt => opt.MapFrom(x => x.CelebrationsCategoty.Select(x => x.Category)))
                .ForMember(x => x.WorkingTimes, opt => opt.MapFrom(x => x.CelebrationsWorkingTime.Select(x => x.WorkingTime)));

            CreateMap<File, IFormFile>()
                .ForMember(x => x.FileName, opt => opt.MapFrom(x => x.Name));

            CreateMap<IFormFile, File>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FileName));
        }
    }
}
