namespace CodingSample.Model
{
    public class ListHelper
    {
        public ListResults<T> GetListResults<T>(IEnumerable<T> items, ListSettings listSettings)
        {
            if (items == null)
            {
                return new ListResults<T>();
            }

            if (listSettings == null)
            {
                return new ListResults<T>
                {
                    TotalPages = 1,
                    PageData = items
                };
            }

            var queryable = items.AsQueryable();

            if (!string.IsNullOrEmpty(listSettings.SortBy))
            {
                queryable = queryable.OrderBy(listSettings.SortBy, listSettings.SortDirection);
            }

            items = queryable.ToList();

            var listResults = new ListResults<T>
            {
                PageStart = 1,
                PageEnd = items.Count(),
                TotalCount = items.Count(),
                TotalPages = 1
            };

            listResults.PageData = items;
            listResults.SortBy = listSettings.SortBy;
            listResults.SortDirection = listSettings.SortDirection;

            return listResults;
        }
    }
}
