using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Core.Concretes.Enums;
using Core.Concretes.Models;
using Core.Utils;
using System.Linq.Expressions;

namespace Business.Services
{
    public class JobApplicationService(IUnitOfWork unitOfWork, IMapper mapper) : IJobApplicationService
    {
        public async Task<Reply> ApplyAsync(string jobId, string candidateId, string? resumeUrl = null)
        {
            var application = new JobApplication
            {
                JobPostingId = jobId,
                CandidateId = candidateId,
                ResumeUrl = resumeUrl,
            };
            var repo = unitOfWork.Repository<JobApplication>();
            await repo.CreateAsync(application);
            return await unitOfWork.CommitAsync();
        }

        public async Task<Reply> ChangeStatusAsync(string jobId, ApplicationStatus status)
        {
            var repo = unitOfWork.Repository<JobApplication>();
            var application = await repo.ReadOneAsync(jobId);
            if (application == null) return Reply.Fail("Kayıt bulunamadı!");

            application.Status = status;
            application.UpdatedAt = DateTime.Now;
            repo.Update(application);
            return await unitOfWork.CommitAsync();
        }

        private async Task<IEnumerable<ApplicationListDto>> listAsync(Expression<Func<JobApplication, bool>> expression)
        {
            var repo = unitOfWork.Repository<JobApplication>();
            var applications = await repo.ReadManyAsync(expression);
            return mapper.Map<IEnumerable<ApplicationListDto>>(applications);
        }

        public async Task<IEnumerable<ApplicationListDto>> ListByCandidateAsync(string id)
        {
            return await listAsync(x => x.CandidateId == id);
        }

        public async Task<IEnumerable<ApplicationListDto>> ListByJobAsync(string id)
        {
            return await listAsync(x => x.JobPostingId == id);
        }

        public async Task<Reply> WithdrawAsync(string jobId, string candidateId)
        {
            var repo = unitOfWork.Repository<JobApplication>();
            var application = await repo.ReadFirstAsync(x => x.CandidateId == candidateId && x.JobPostingId == jobId);
            if (application == null) return Reply.Fail("Kayıt bulunamadı!");

            repo.Delete(application);
            return await unitOfWork.CommitAsync();
        }
    }
}
