namespace Core.Concretes.DTOs
{
    public class JobPostingUpdateDto
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
