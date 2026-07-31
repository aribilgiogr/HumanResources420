using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class JobPostingListDto
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string CompanyId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
    }
}
