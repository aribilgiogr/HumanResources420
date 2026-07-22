using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Website { get; set; }

        public string EmployerId { get; set; } = null!;
        public AppUser Employer { get; set; } = null!;
    }
}
