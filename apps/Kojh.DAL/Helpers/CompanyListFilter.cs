namespace Kojh.DAL.Helpers
{
    public class CompanyListFilter
    {
        public string Search { get; set; } = string.Empty;
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
