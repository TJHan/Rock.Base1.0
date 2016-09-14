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

        public IEnumerable<Entity.orderList> TestFindByFilter()
        {
            var par = new
            {
                p_id = 40000
            };
            IEnumerable<Entity.orderList> list = FindByFilter<Entity.orderList>(@"select o_guid,o_code,e.e_realname from t_orders o
                                                                    left join t_enterprise e on o.o_ownid = e.e_guid WHERE o.o_id>@p_id", par);

            return list;
        }

        public void insertTest()
        {
            Entity.Customer entity = new Entity.Customer();
            entity.CustomerNames = "张先生";
            entity.EnteredDate = DateTime.Now;
            entity.CustomerPhone = "000000111";

            int id = this.InsertEntity<Entity.Customer>(entity);
            if (id > 0)
            { }
        }

        public void UpdateTest()
        {
            Entity.Customer entity = new Entity.Customer();
            entity = this.FindEntity<Entity.Customer>(1, "customerID");            
            entity.CustomerNames = "新的名字22";
            entity.UpdateDate = DateTime.Now;            
            bool result = this.UpdateEntity<Entity.Customer>(entity);
            if (result)
            { }
        }

        public void DeleteTest()
        {
            bool result = this.DeleteEntity<Entity.Customer>(3);
            if (result)
            { }
        }

        public IEnumerable<Entity.Customer> PagingTest()
        {
            int total = 0;
            string orderby = "";
            string filter = "";
            var para = new
            {
                p_name = "asdfddd"
            };
            IEnumerable<Entity.Customer> list = this.Select<Entity.Customer>(1, 5, out total, filter, orderby, para);

            return list;

        }
    }
}
