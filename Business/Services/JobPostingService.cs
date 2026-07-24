using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Core.Concretes.Models;
using Core.Utils;

namespace Business.Services
{
    public class JobPostingService(IUnitOfWork unitOfWork, IMapper mapper) : IJobPostingService
    {
        public async Task<Reply> AddAsync(JobPostingCreateDto dto)
        {
            var jobPosting = mapper.Map<JobPosting>(dto);
            var repo = unitOfWork.Repository<JobPosting>();
            await repo.CreateAsync(jobPosting);
            return await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<JobPostingListDto>> GetAllAsync(string? companyId)
        {
            var repo = unitOfWork.Repository<JobPosting>();
            var jobPostings = await repo.ReadManyAsync(x => companyId == null || x.CompanyId == companyId);
            return mapper.Map<IEnumerable<JobPostingListDto>>(jobPostings);
        }

        public Task<JobPostingDetailDto?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Reply> RemoveAsync(string jobId)
        {
            throw new NotImplementedException();
        }

        public Task<Reply> SetAsync(JobPostingUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
