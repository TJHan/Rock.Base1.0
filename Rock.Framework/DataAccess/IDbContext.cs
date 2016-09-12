using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;

namespace Rock.Framework.DataAccess
{
    public interface IDbContext
    {
        T FindEntity<T>(int id, string keyColumnName) where T : new();
        T FindEntity<T>(Guid guid, string keyColumnName) where T : new();

        int InsertEntity<T>(T entity);
        bool UpdateEntity(Common.IEntity entity);
        bool DeleteEntity(Common.IEntity entity);

        int ExecuteNonQuery(string sql);
        int ExecuteNonQuery(string sql, params object[] paramsList);
        int ExecuteNonQuery(string sql, object paramsList);
        int ExecuteNonQuery(SqlCommand cmd);

        object ExecuteScalar(string sql);
        object ExecuteScalar(string sql, params object[] paramsList);
        object ExecuteScalar(string sql, object paramsList);
        object ExecuteScalar(SqlCommand cmd);

        SqlDataReader ExecuteReader(string sql);
        SqlDataReader ExecuteReader(SqlCommand cmd);

    }
}
