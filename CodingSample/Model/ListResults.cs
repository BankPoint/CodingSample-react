namespace CodingSample.Model
{
    public class ListResults<T>
    {
        public int PageStart { get; set; }
        public int PageEnd { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> PageData { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }

        public ListResults()
        {
        }
    }
}
