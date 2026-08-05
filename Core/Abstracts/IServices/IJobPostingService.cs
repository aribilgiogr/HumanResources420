using Core.Concretes.DTOs;
using Core.Concretes.Models;

namespace Core.Abstracts.IServices
{
    public interface IJobPostingService
    {
        Task<IEnumerable<JobPostingListDto>> GetAllAsync(string? companyId);
        Task<JobPostingDetailDto?> GetByIdAsync(string id);
        Task<JobPostingUpdateDto> GetForEditByIdAsync(string id);
        Task<Reply> AddAsync(JobPostingCreateDto dto);
        Task<Reply> SetAsync(JobPostingUpdateDto dto, string companyId);
        Task<Reply> RemoveAsync(string jobId);
    }
}
