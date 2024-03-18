namespace TETEX.Models.Pagination
{
    public class PaginatedList<T>: List<T>
    {
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
        public PaginatedList(List<T> item, int cont, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalCount = (int)Math.Ceiling(Count / (double)pageSize);
            AddRange(item);
                }

    }
}
