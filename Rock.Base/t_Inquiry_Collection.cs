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
    
    public partial class t_Inquiry_Collection
    {
        public long Collection_Id { get; set; }
        public string Apply_Code { get; set; }
        public System.Guid Apply_Id { get; set; }
        public string Apply_ProChengFen { get; set; }
        public string Apply_ProShaZhi { get; set; }
        public int Apply_ProGuShu { get; set; }
        public string Apply_ProChengShaSheBei { get; set; }
        public string Apply_ProYongtu { get; set; }
        public string AppLy_Pro_GuiType { get; set; }
        public string AppLy_SupplyType { get; set; }
        public decimal AppLy_Quantity { get; set; }
        public System.DateTime AppLy_ExpiryDate { get; set; }
        public Nullable<System.DateTime> Collection_Date { get; set; }
        public Nullable<System.Guid> Collection_UserId { get; set; }
    }
}