using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class JobPosting : BaseEntity // İş ilanı
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        public string CompanyId { get; set; } = null!;
        public Company Company { get; set; } = null!;
        public ICollection<JobApplication> Applications { get; set; } = [];
    }
}
