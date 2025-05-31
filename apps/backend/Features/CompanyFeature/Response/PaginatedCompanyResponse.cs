using System.ComponentModel.DataAnnotations;

namespace backend.Features.CompanyFeature.Response
{
    public class PaginatedCompanyResponse
    {
        [Required] public int TotalCount { get; set; }
        public List<CompanyResponse> Companies { get; set; } = [];
    }
}
