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
    
    public partial class v_Licence
    {
        public long rg_id { get; set; }
        public System.Guid rg_guid { get; set; }
        public string rg_type { get; set; }
        public Nullable<System.Guid> rg_typeid { get; set; }
        public string rg_right { get; set; }
        public byte rg_fatal { get; set; }
        public string rg_caption { get; set; }
        public string rg_memo { get; set; }
        public long le_id { get; set; }
        public Nullable<System.Guid> le_guid { get; set; }
        public Nullable<System.Guid> le_usrguid { get; set; }
        public string le_role { get; set; }
        public System.Guid le_rgid { get; set; }
    }
}
