using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Rock.Framework.Attributes;

namespace Rock.Base.Entity
{
    [EntityMapping(TableName = "Customer")]
    public class Customer
    {
        [PrimaryKey(PrimaryKeyColumnName = "CustomerID")]
        public int CustomerID { get; set; }

        [EntityMapping(ColumnName = "CustomerName")]
        public string CustomerNames { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime EnteredDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
    }
        
    public class orderList
    {
        public Guid o_guid { get; set; }
        public string o_code { get; set; }

        [EntityMapping(ColumnName = "e_realname")]
        public string UserName { get; set; }
    }
}
