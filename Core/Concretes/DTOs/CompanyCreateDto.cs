using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class CompanyCreateDto
    {
        [Display(Name = "Kurum Adı", Prompt = "Kurum Adı"), Required]
        public string Name { get; set; } = null!;

        [Display(Name = "Kısa Açıklama", Prompt = "Kısa Açıklama"), DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Display(Name = "Website", Prompt = "Website"), DataType(DataType.Url)]
        public string? Website { get; set; }
    }
}
