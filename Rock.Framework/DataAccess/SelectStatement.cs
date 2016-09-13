using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock.Framework.DataAccess
{
    public class SelectStatement
    {
        public SelectStatement()
        { }

        public static string PagingSelectStatement(string tableName, string fields, int pageIndex, int pageSize, string filter, string orderBy)
        {
            string whereStr = string.IsNullOrEmpty(filter) ? string.Empty : string.Format(@"WHERE {0}", filter);
            string sql = string.Format(@"WITH PagingTable AS(
                                SELECT TOP {4} {2}, ROW_NUMBER() OVER(ORDER BY {3}) AS RowNbr FROM {0} {1}
                                )
                                SELECT * FROM PagingTable WHERE RowNbr >{5};
                                SELECT COUNT(*) FROM {0} {1};", tableName
                                                              , whereStr
                                                              , fields
                                                              , string.IsNullOrEmpty(orderBy) ? "1" : orderBy
                                                              , pageIndex * pageSize
                                                              , pageSize * (pageIndex - 1));
            return sql;
        }
    }
}
