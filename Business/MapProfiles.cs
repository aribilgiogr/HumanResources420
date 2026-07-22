using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;

namespace Business
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            // Entity -> DTO
            CreateMap<JobPosting, JobPostingListDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            // DTO -> Entity
            CreateMap<JobPostingCreateDto, JobPosting>();
        }
    }
}
