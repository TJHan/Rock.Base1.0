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
    }
}
