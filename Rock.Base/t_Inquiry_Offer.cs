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
    
    public partial class t_Inquiry_Offer
    {
        public System.Guid Offer_Id { get; set; }
        public System.Guid Offer_UserId { get; set; }
        public System.DateTime Offer_Date { get; set; }
        public System.Guid Offer_ApplyId { get; set; }
        public string Offer_ApplyCode { get; set; }
        public string Apply_ProShaZhi { get; set; }
        public int Apply_ProGuShu { get; set; }
        public string Apply_ProPlace { get; set; }
        public string Apply_ProChengFen { get; set; }
        public string Apply_ProClass { get; set; }
        public string Apply_ProYongtu { get; set; }
        public decimal AppLy_Quantity { get; set; }
        public string AppLy_SupplyType { get; set; }
        public string AppLy_Pro_GuiType { get; set; }
        public System.DateTime AppLy_ExpiryDate { get; set; }
        public decimal Offer_ProPrice { get; set; }
        public decimal Offer_Price { get; set; }
        public System.Guid Offer_ProId { get; set; }
        public string Offer_Status { get; set; }
        public bool Offer_bDel { get; set; }
        public bool Offer_ViewStatus { get; set; }
        public bool Offer_bTrash { get; set; }
    }
}
