using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock.Framework.DataAccess;

namespace Rock.Base.DataAccess
{
    public class BaseDBContext : MSSqlContext
    {
        public BaseDBContext(string conn)
            : base(conn)
        {

        }

        public void ExecuteSQL(string sqlString)
        {
            using (MSSqlContext context = MSSqlContext.BeginTransaction(this.ROCKSqlConnection.ConnectionString))
            {
                try
                {
                    sqlString = @"UPDATE t_enterprise SET e_regdate=GETDATE() WHERE e_realname=@p_name";
                    var d = new
                    {
                        p_name = "王的强"
                    };
                    context.ExecuteNonQuery(sqlString, d);

                    context.ExecuteNonQuery("UPDATE T_DD SET D=''");
                    context.Commit();
                }
                catch
                {
                    context.RollBack();
                }
                finally
                {
                    context.Close();
                }
            }

        }

        public void TestFindByFilter()
        {
            IEnumerable<Entity.Customer> list = FindByFilter<Entity.Customer>("SELECT e_guid,e_realname FROM t_enterprise WHERE e_id<100");
            if (list != null)
            { }
        }

        public void insertTest()
        {
            Entity.Customer entity = new Entity.Customer();
            entity.CustomerName = "张先生";
            entity.EnteredDate = DateTime.Now;
            entity.CustomerPhone = "000000111";

            int id = this.InsertEntity<Entity.Customer>(entity);
            if (id > 0)
            { }
        }

        public void UpdateTest()
        {
            Entity.Customer entity = new Entity.Customer();
            entity.CustomerID = 1;
            entity.CustomerName = "新的名字";
            entity.UpdateDate = DateTime.Now;
            bool result = this.UpdateEntity<Entity.Customer>(entity, "customername", "updatedate");
            if (result)
            { }
        }

        public void DeleteTest()
        {
            bool result = this.DeleteEntity<Entity.Customer>(3);
            if (result)
            { }
        }

        public void PagingTest()
        {
            int total = 0;
            string orderby = " customername desc";
            string filter = " customerName like @p_name";
            var para = new
            {
                p_name = ""
            };
            IEnumerable<Entity.Customer> list = this.Select<Entity.Customer>(1, 5, out total, filter, orderby, para);
            if (list.ToList().Count > 0)
            { }

        }
    }
}
