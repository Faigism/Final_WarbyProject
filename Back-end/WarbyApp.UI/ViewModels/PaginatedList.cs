namespace WarbyApp.UI.ViewModels
{
    public class PaginatedList<T>
    {
        public PaginatedList(List<T> items, int pageindex, int totalpage)
        {
            Items = items;
            PageIndex = pageindex;
            TotalPage = totalpage;
        }
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public bool HasPrevious => PageIndex > 1;
        public bool HasNext => PageIndex < TotalPage;
        public static PaginatedList<T> Create(IQueryable<T> query, int pageIndex, int pageSize)
        {
            var items = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var totalPages = (int)Math.Ceiling(query.Count() / (double)pageSize);
            return new PaginatedList<T>(items, pageIndex, totalPages);
        }
    }
}
