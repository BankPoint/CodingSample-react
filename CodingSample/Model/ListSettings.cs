namespace CodingSample.Model
{
    public class ListSettings
    {
        public string SortBy { get; set; }
        public string SortDirection { get; set; }

        public ListSettings() { }

        public ListSettings(string sortBy, string sortDirection)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
        }
    }
}
