﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rock.Framework.DataAccess
{
    public class MSSqlContext : DbContext, IDbContext
    {
        public SqlConnection ROCKSqlConnection
        {
            get
            {
                return this.Database.Connection as SqlConnection;
            }
        }

        public SqlTransaction ROCKSqlTransaction { get; private set; }

        public bool IsTransaction { get; private set; }

        public MSSqlContext(string connectionString, bool transaction = false)
            : base(connectionString)
        {
            this.IsTransaction = transaction;
            this.Database.CommandTimeout = 300;
        }

        public MSSqlContext(SqlConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection) { }

        #region 事务处理
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <param name="isolationLevel">事务隔离级别</param>
        /// <returns></returns>
        public bool Open(IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
        {
            if (this.Database.Connection.State != ConnectionState.Open)
            {
                this.Database.Connection.Open();
                if (this.Database.Connection.State != ConnectionState.Open)
                {
                    return false;
                }
                if (IsTransaction && ROCKSqlTransaction == null)
                {
                    ROCKSqlTransaction = this.Database.Connection.BeginTransaction(isolationLevel) as SqlTransaction;
                }
            }
            return true;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            if (this.Database.Connection.State == ConnectionState.Open)
            {
                this.Database.Connection.Close();
                if (this.ROCKSqlTransaction != null)
                {
                    this.ROCKSqlTransaction.Dispose();
                    this.ROCKSqlTransaction = null;
                }
                if (this.Database.Connection.State != ConnectionState.Closed)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 提交SQL事务
        /// </summary>
        public void Commit()
        {
            if (IsTransaction)
            {
                if (ROCKSqlTransaction != null)
                {
                    this.ROCKSqlTransaction.Commit();
                    this.ROCKSqlTransaction.Dispose();
                    this.ROCKSqlTransaction = null;
                }
            }
        }

        /// <summary>
        /// 回滚SQL事务
        /// </summary>
        public void RollBack()
        {
            if (IsTransaction)
            {
                if (ROCKSqlTransaction != null)
                {
                    this.ROCKSqlTransaction.Rollback();
                    this.ROCKSqlTransaction.Dispose();
                    this.ROCKSqlTransaction = null;
                }
            }
        }

        /// <summary>
        /// 生成SQL事务操作的DB访问Context的静态工厂
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public static MSSqlContext BeginTransaction(string connectionString, IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
        {
            MSSqlContext context = new MSSqlContext(connectionString, true);
            context.Open(isolationLevel);
            return context;
        }
        #endregion

        #region 执行基础命令
        /// <summary>
        /// 根据自增主键ID查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">自增主键id</param>
        /// <param name="keyColumnName">主键字段名称</param>
        /// <returns></returns>
        public T FindEntity<T>(int id, string keyColumnName) where T : new()
        {
            Type tType = typeof(T);
            string sql = string.Format(@"SELECT * FROM {0} WHERE {1} = @p_key", tType.Name, keyColumnName);
            var para = new
            {
                p_key = id
            };
            return FindByFilter<T>(sql, para).FirstOrDefault();
        }

        /// <summary>
        /// 根据主键GUID查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid">主键GUID</param>
        /// <param name="keyColumnName">主键字段名称</param>
        /// <returns></returns>
        public T FindEntity<T>(Guid guid, string keyColumnName) where T : new()
        {
            Type tType = typeof(T);
            string sql = string.Format(@"SELECT * FROM {0} WHERE {1} = @p_key", tType.Name, keyColumnName);
            var para = new
            {
                p_key = guid
            };
            return FindByFilter<T>(sql, para).FirstOrDefault();
        }

        /// <summary>
        /// 添加实体的数据到数据库
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">插入DB的实体类对象</param>
        /// <returns></returns>
        public int InsertEntity<T>(T entity)
        {
            Type tType = entity.GetType();
            PropertyInfo[] propList = tType.GetProperties();

            string sql = string.Format(@"INSERT INTO {0} (", tType.Name);
            propList = propList.Where(d => d.GetCustomAttribute<Attributes.PrimaryKeyAttribute>(true) == null).ToArray();
            string[] columnNameList = propList.Select(p => p.Name).ToArray();
            string[] paraList = propList.Select(p => string.Format(@"@{0}", p.Name)).ToArray();
            Dictionary<string, object> paraDict = new Dictionary<string, object>();

            propList.ToList().ForEach(d =>
            {
                paraDict.Add(d.Name, d.GetValue(entity) ?? DBNull.Value);
            });

            string fields = string.Join(",", columnNameList);
            string paras = string.Join(",", paraList);

            sql += string.Format(@"{0})VALUES({1});", fields, paras);
            sql += "SELECT SCOPE_IDENTITY();";

            return Convert.ToInt32(this.ExecuteScalar(sql, paraDict));
        }

        /// <summary>
        /// 修改实体对象
        /// </summary>
        /// <typeparam name="T">待修改的对象类型</typeparam>
        /// <param name="entity">待修改的对象</param>
        /// <param name="UpdateFields">要修改的字段</param>
        /// <returns></returns>
        public bool UpdateEntity<T>(T entity, params string[] UpdateFields)
        {
            if (UpdateFields.Length == 0)
                return false;

            Type tType = entity.GetType();
            PropertyInfo[] propList = tType.GetProperties();
            PropertyInfo keyProperty = propList.Where(d => d.GetCustomAttribute<Attributes.PrimaryKeyAttribute>(true) != null).FirstOrDefault();
            if (keyProperty == null)
                return false;
            object primaryKeyValue = keyProperty.GetValue(entity);
            if (primaryKeyValue == null)
                return false;

            Attributes.EntityMappingAttribute entityAttr = tType.GetCustomAttributes<Attributes.EntityMappingAttribute>(true).FirstOrDefault();
            string tableName = entityAttr != null ? entityAttr.TableName : tType.Name;
            string sql = string.Format(@"UPDATE {0} SET ", tableName);

            string sqlQuery = string.Empty;
            Dictionary<string, object> paraList = new Dictionary<string, object>();
            foreach (var field in UpdateFields)
            {
                sqlQuery += string.Format(@",{0}=@{0}", field);
                PropertyInfo prop = propList.Where(d => d.Name.Equals(field, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                object value = DBNull.Value;
                if (prop != null)
                    value = prop.GetValue(entity);
                paraList.Add(field, value);
            }
            sql += sqlQuery.Substring(1) ?? string.Empty;
            sql += string.Format(@" WHERE {0} = @{0}", keyProperty.Name);
            paraList.Add(keyProperty.Name, primaryKeyValue);

            return this.ExecuteNonQuery(sql, paraList) > 0;
        }

        public bool DeleteEntity<T>(object primaryKey)
        {
            Type tType = typeof(T);
            PropertyInfo property = tType.GetProperties().Where(d => d.GetCustomAttributes<Attributes.PrimaryKeyAttribute>(true) != null).FirstOrDefault();
            if (property == null)
                return false;
            Attributes.EntityMappingAttribute emAttr = tType.GetCustomAttributes<Attributes.EntityMappingAttribute>(true).FirstOrDefault();
            string tableName = emAttr != null ? emAttr.TableName ?? tType.Name : tType.Name;

            string sql = string.Format(@"DELETE FROM {0} WHERE {1} = @{1}", tableName, property.Name);
            Dictionary<string, object> paraList = new Dictionary<string, object>();
            paraList.Add(property.Name, primaryKey);

            return ExecuteNonQuery(sql, paraList) > 0;
        }


        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(this.CreateSqlCommand(sql, null));
        }

        public int ExecuteNonQuery(string sql, params object[] paramsList)
        {
            return ExecuteNonQuery(this.CreateSqlCommand(sql, paramsList));
        }

        public int ExecuteNonQuery(string sql, object paramsList)
        {
            return ExecuteNonQuery(this.CreateSqlCommand(sql, paramsList));
        }

        /// <summary>
        /// 执行SQL命令，返回影响的记录数
        /// </summary>
        /// <param name="cmd">SqlCommand实例,即要对MSSQL执行的SQL操作</param>
        /// <returns>返回影响的记录数</returns>
        public int ExecuteNonQuery(SqlCommand cmd)
        {
            if (this.Database.Connection.State != ConnectionState.Open)
                this.Open();

            if (this.Database.CommandTimeout.HasValue)
                cmd.CommandTimeout = this.Database.CommandTimeout.Value;
            if (IsTransaction)
                cmd.Transaction = this.ROCKSqlTransaction;
            int result = -1;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format(@"Command:{0} \r\n Message:{1}", cmd.CommandText, e.Message));
            }
            finally
            {
                if (!IsTransaction)
                    this.Close();
            }
            return result;
        }

        public object ExecuteScalar(string sql)
        {
            return this.ExecuteScalar(this.CreateSqlCommand(sql, null));
        }

        public object ExecuteScalar(string sql, params object[] paramsList)
        {
            return this.ExecuteScalar(this.CreateSqlCommand(sql, paramsList));
        }

        public object ExecuteScalar(string sql, object paramsList)
        {
            return this.ExecuteScalar(this.CreateSqlCommand(sql, paramsList));
        }

        /// <summary>
        /// 执行SQL命令，返回查询的第一行第一列的值
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public object ExecuteScalar(SqlCommand cmd)
        {
            if (this.Database.Connection.State != ConnectionState.Open)
                this.Open();
            if (IsTransaction)
                cmd.Transaction = this.ROCKSqlTransaction;
            if (this.Database.CommandTimeout.HasValue)
                cmd.CommandTimeout = this.Database.CommandTimeout.Value;
            object result;
            try
            {
                result = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format(@"Command:{0} \r\n Message:{1}", cmd.CommandText, e.Message));
            }
            finally
            {
                if (!IsTransaction)
                    this.Close();
            }
            return result;
        }

        public System.Data.SqlClient.SqlDataReader ExecuteReader(string sql)
        {
            throw new NotImplementedException();
        }

        public System.Data.SqlClient.SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 查询函数

        public IEnumerable<T> FindByFilter<T>(string sql, object para = null) where T : new()
        {
            return FindByFilter<T>(CreateSqlCommand(sql, para));
        }

        public IEnumerable<T> FindByFilter<T>(SqlCommand cmd) where T : new()
        {
            if (this.Database.Connection.State != ConnectionState.Open)
                this.Open();
            if (this.IsTransaction)
                cmd.Transaction = this.ROCKSqlTransaction;
            if (this.Database.CommandTimeout.HasValue)
                cmd.CommandTimeout = this.Database.CommandTimeout.Value;

            IEnumerable<T> result = null;
            try
            {
                result = this.FindByFilter<T>(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Command:{0}\r\nMessage:{1}", cmd.CommandText, e.Message));
            }
            finally
            {
                if (!this.IsTransaction)
                    this.Close();
            }
            return result;
        }

        private IEnumerable<T> FindByFilter<T>(SqlDataReader reader) where T : new()
        {
            List<T> result = new List<T>();
            if (!reader.HasRows)
                return null;

            using (DataTable readerSchema = reader.GetSchemaTable())
            {
                Type tType = typeof(T);
                PropertyInfo[] tPropList = tType.GetProperties();
                //IEnumerable<PropertyInfo> cfpropList = tPropList.Where(d => d.GetCustomAttributes<ColumnAttribute>().Any());

                Dictionary<string, PropertyInfo> propDict = new Dictionary<string, PropertyInfo>();
                foreach (var item in tPropList)
                {
                    if (propDict.ContainsKey(item.Name))
                        propDict[item.Name] = item;
                    else
                        propDict.Add(item.Name, item);
                }

                while (reader.Read())
                {
                    T t = new T();
                    foreach (DataRow row in readerSchema.Rows)
                    {
                        string pName = row["ColumnName"].ToString();
                        PropertyInfo propertyInfo = tType.GetProperty(pName);
                        if (propertyInfo == null)
                        {
                            if (propDict.ContainsKey(pName))
                                propertyInfo = propDict[pName];
                            else
                                continue;
                        }
                        if (!propertyInfo.CanWrite)
                            continue;

                        try
                        {
                            object value = reader[pName];
                            if (value != DBNull.Value)
                            {
                                //设置指定对象的属性值
                                propertyInfo.SetValue(t, value, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format("{0} 转换出错 ：{1}", propertyInfo.Name, ex.Message));
                        }

                    }
                    result.Add(t);
                }
            }
            reader.Close();
            return result;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="totalRecortCount">数据总条数</param>
        /// <param name="filter">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="para">查询条件使用的参数</param>
        /// <returns>DataTable</returns>
        public DataTable FindByFilter<T>(int pageIndex, int pageSize, out int totalRecortCount, string filter, string orderBy, object para) where T : new()
        {
            Type tType = typeof(T);
            PropertyInfo[] propList = tType.GetProperties();
            string[] columnList = propList.Select(d => d.Name).ToArray();
            string fields = string.Join(",", columnList);           

            string sql = SelectStatement.PagingSelectStatement(tType.Name, fields, pageIndex, pageSize, filter, orderBy);
            SqlCommand cmd = new SqlCommand(sql, ROCKSqlConnection);
            if (para != null)
            {
                ConvertCommandParameters(cmd.Parameters, para, true);
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            totalRecortCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds.Tables[0];
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据条数</param>
        /// <param name="toatalRecordCount">数据总条数</param>
        /// <param name="filter">查询条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="para">查询条件使用的参数</param>
        /// <returns>T集合</returns>
        public IEnumerable<T> Select<T>(int pageIndex, int pageSize, out int toatalRecordCount, string filter, string orderBy, object para) where T : new()
        {
            DataTable dt = FindByFilter<T>(pageIndex, pageSize, out toatalRecordCount, filter, orderBy, para);
            List<T> ts = new List<T>();
            string tempName = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName))
                    {
                        if (!pi.CanWrite)
                            continue;
                        object value = row[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                ts.Add(t);
            }
            return ts;
        }
        #endregion




        /// <summary>
        /// 生成SqlCommand
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <param name="isAllowNull"></param>
        /// <returns></returns>
        public SqlCommand CreateSqlCommand(string sql, object para, bool isAllowNull = false)
        {
            SqlCommand cmd = new SqlCommand(sql, ROCKSqlConnection);
            if (para != null)
            {
                ConvertCommandParameters(cmd.Parameters, para, isAllowNull);
            }
            return cmd;
        }

        /// <summary>
        /// 处理参数集合，生成为SQL参数集合
        /// </summary>
        /// <param name="sqlParaCo">集合类</param>
        /// <param name="para">实体类实例或者字典集合</param>
        /// <param name="isAllowNull">参数是否允许为NULL</param>
        private void ConvertCommandParameters(SqlParameterCollection sqlParaCo, object para, bool isAllowNull)
        {
            if (para == null)
                return;
            Type paraType = para.GetType();
            //参数集合是地点类型的分流到对应的重载方法里
            if (paraType.Equals(typeof(Dictionary<string, object>)))
            {
                ConvertDictionaryParameters(sqlParaCo, (Dictionary<string, object>)para, isAllowNull);
                return;
            }
            PropertyInfo[] propertyList = para.GetType().GetProperties().Where(d => d.CanRead && (isAllowNull || d.GetValue(para) != null)).ToArray();
            if (propertyList.Length == 0)
                return;

            foreach (var item in propertyList)
            {
                object value = item.GetValue(para);
                if (value == null)
                    value = DBNull.Value;
                sqlParaCo.Add(new SqlParameter(item.Name, value));
            }

        }

        /// <summary>
        /// 处理字典类型的参数集合，生成为SQL参数集合
        /// </summary>
        /// <param name="sqlParaCo"></param>
        /// <param name="dicList"></param>
        /// <param name="isAllowNull"></param>
        private void ConvertDictionaryParameters(SqlParameterCollection sqlParaCo, Dictionary<string, object> dicList, bool isAllowNull)
        {
            var pList = dicList.Where(d => isAllowNull || d.Value != null);
            foreach (var item in pList)
            {
                var value = item.Value;
                if (value == null)
                    value = DBNull.Value;
                sqlParaCo.Add(item.Key, value);
            }
        }



    }
}
