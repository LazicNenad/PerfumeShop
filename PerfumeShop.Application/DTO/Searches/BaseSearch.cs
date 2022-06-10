namespace PerfumeShop.Application.DTO.Searches
{
    public class BaseSearch
    {
        public string? Keyword { get; set; } 
    }

    public class PagedSearch : BaseSearch
    {
        public int? PerPage { get; set; } = 10;
        public int? Page { get; set; } = 1;
    }
}
