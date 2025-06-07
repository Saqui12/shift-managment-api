namespace Dominio.Models.Parameters
{
    public class PagedResults<T>
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
        public IEnumerable<T> Items { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < (TotalCount + PageSize - 1) / PageSize;
        public int? TotalPages => (TotalCount + PageSize - 1) / PageSize;

        public PagedResults(IEnumerable<T> item,int totalCount,int pageNumber,int pageSize)
        {
            Items = item;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

    }
}
