using Core.Abstracts.Bases;
using Core.Concretes.Enums;

namespace Core.Concretes.Entities
{
    public class JobApplication : BaseEntity
    {
        public string JobPostingId { get; set; } = null!;
        public JobPosting JobPosting { get; set; } = null!;

        public string CandidateId { get; set; } = null!;
        public AppUser Candidate { get; set; } = null!;

        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public string? ResumeUrl { get; set; }
    }
}
