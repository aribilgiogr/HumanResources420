using Core.Concretes.Enums;

namespace Core.Concretes.DTOs
{
    public class ApplicationListDto
    {
        public string Id { get; set; } = null!;
        public string JobId { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string CadidateFullName { get; set; } = null!;
        public ApplicationStatus Status { get; set; }
        public string? ResumeUrl { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
