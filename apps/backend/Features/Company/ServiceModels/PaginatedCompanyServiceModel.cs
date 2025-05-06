namespace backend.Features.Company.ServiceModels
{
    public class PaginatedCompanyServiceModel
    {
        public string Search { get; set; } = string.Empty;
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public int TotalCount { get; set; }
        public List<CompanyServiceModel> Companies { get; set; } = [];
    }
}
