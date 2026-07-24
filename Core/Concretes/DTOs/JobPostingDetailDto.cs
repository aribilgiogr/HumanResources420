namespace Core.Concretes.DTOs
{
    public class JobPostingDetailDto
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CompanyId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public int ApplicationCount { get; set; }
    }
}
