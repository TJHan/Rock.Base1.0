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
    
    public partial class t_vat_items
    {
        public int vi_id { get; set; }
        public System.Guid vi_guid { get; set; }
        public string vi_No { get; set; }
        public string vi_TFN { get; set; }
        public string vi_productName { get; set; }
        public string vi_productCount { get; set; }
        public string vi_unit { get; set; }
        public decimal vi_dutiablePrice { get; set; }
        public string vi_taxRate { get; set; }
        public decimal vi_taxAmount { get; set; }
    }
}