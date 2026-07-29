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

        public async Task<JobPostingDetailDto?> GetByIdAsync(string id)
        {
            var repo = unitOfWork.Repository<JobPosting>();
            var jobPosting = await repo.ReadOneAsync(id);
            return mapper.Map<JobPostingDetailDto>(jobPosting);
        }

        public async Task<Reply> RemoveAsync(string jobId)
        {
            var repo = unitOfWork.Repository<JobPosting>();
            var jobPosting = await repo.ReadOneAsync(jobId);
            if (jobPosting != null)
            {
                repo.Delete(jobPosting);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Kayıt bulunamadı!");
        }

        public async Task<Reply> SetAsync(JobPostingUpdateDto dto)
        {
            var repo = unitOfWork.Repository<JobPosting>();
            if (await repo.AnyAsync(x => x.Id == dto.Id))
            {
                var job = mapper.Map<JobPosting>(dto);
                repo.Update(job);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Kayıt bulunamadı!");
        }
    }
}
