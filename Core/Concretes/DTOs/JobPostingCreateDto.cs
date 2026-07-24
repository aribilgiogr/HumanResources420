namespace Core.Concretes.DTOs
{
    public class JobPostingCreateDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string CompanyId { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
    }
}
