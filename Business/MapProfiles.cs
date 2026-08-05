using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;

namespace Business
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            // Entity -> List DTO
            CreateMap<JobPosting, JobPostingListDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            // Create DTO -> Entity
            CreateMap<JobPostingCreateDto, JobPosting>();

            // Entity -> Detail DTO
            CreateMap<JobPosting, JobPostingDetailDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.ApplicationCount, opt => opt.MapFrom(src => src.Applications != null ? src.Applications.Count() : 0));

            // Update DTO -> Entity
            CreateMap<JobPostingUpdateDto, JobPosting>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            // Entity -> Update DTO
            CreateMap<JobPosting, JobPostingUpdateDto>();
        }
    }
}
