//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rock.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class EInstanceAudit
    {
        public System.Guid Id { get; set; }
        public string BusinessCode { get; set; }
        public System.Guid InstanceId { get; set; }
        public string OperateUser { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.Guid StateId { get; set; }
    }
}
