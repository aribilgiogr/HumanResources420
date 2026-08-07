using Core.Concretes.DTOs;
using Core.Concretes.Enums;
using Core.Concretes.Models;

namespace Core.Abstracts.IServices
{
    public interface IJobApplicationService
    {
        Task<Reply> ApplyAsync(string jobId, string candidateId, string? resumeUrl = null);
        Task<Reply> WithdrawAsync(string jobId, string candidateId);
        Task<Reply> ChangeStatusAsync(string jobId, ApplicationStatus status);

        Task<IEnumerable<ApplicationListDto>> ListByJobAsync(string id);
        Task<IEnumerable<ApplicationListDto>> ListByCandidateAsync(string id);
    }
}
