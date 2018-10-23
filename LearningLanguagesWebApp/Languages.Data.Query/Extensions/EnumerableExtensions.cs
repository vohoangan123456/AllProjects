using System.Collections.Generic;
using System.Data;

namespace Languages.Data.Query.Extensions
{
    public static class EnumerableExtensions
    {
        public static DataTable ConvertToDataTable(this IEnumerable<int> source)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Value", typeof(int));
            if (source != null)
            {
                foreach (var item in source)
                {
                    dt.Rows.Add(item, item);
                }
            }
            return dt;
        }
    }
}
