using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class JobPostingCreateDto
    {
        [Display(Name = "İlan Başlığı", Prompt = "İlan Başlığı"), Required, StringLength(150)]
        public string Title { get; set; } = null!;

        [Display(Name = "İlan Açıklaması", Prompt = "İlan Açıklaması"), Required, StringLength(4000, MinimumLength = 10), DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;

        [Display(Name = "Konum", Prompt = "Konum"), Required]
        public string Location { get; set; } = null!;

        public string CompanyId { get; set; } = null!;

        [Display(Name = "Geçerlilik Tarihi", Prompt = "Geçerlilik Tarihi"), Required, DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
    }
}
