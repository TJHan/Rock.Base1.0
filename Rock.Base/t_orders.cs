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
    
    public partial class t_orders
    {
        public long o_id { get; set; }
        public Nullable<System.Guid> o_guid { get; set; }
        public Nullable<System.Guid> o_wfid { get; set; }
        public string o_code { get; set; }
        public Nullable<System.DateTime> o_signDate { get; set; }
        public System.DateTime o_indate { get; set; }
        public Nullable<int> o_type_id { get; set; }
        public Nullable<System.Guid> o_Inquiryofferid { get; set; }
        public Nullable<System.DateTime> o_completionDate { get; set; }
        public string o_own { get; set; }
        public string o_ownParty { get; set; }
        public string o_ownCompany { get; set; }
        public string o_ownCompanyEng { get; set; }
        public System.Guid o_ownid { get; set; }
        public string o_supplierParty { get; set; }
        public string o_supplierCompany { get; set; }
        public string o_supplierCompanyEng { get; set; }
        public string o_supplierBeneficiary { get; set; }
        public System.Guid o_supplierid { get; set; }
        public string o_platParty { get; set; }
        public string o_platCompany { get; set; }
        public string o_platCompanyEng { get; set; }
        public Nullable<System.Guid> o_platid { get; set; }
        public string o_lcmakerParty { get; set; }
        public string o_lcCompany { get; set; }
        public string o_lcCompanyEng { get; set; }
        public Nullable<System.Guid> o_lcid { get; set; }
        public Nullable<System.Guid> o_lcSetId { get; set; }
        public Nullable<decimal> o_lcRate { get; set; }
        public System.Guid o_productid { get; set; }
        public string o_jiaohuodate { get; set; }
        public int o_amunt { get; set; }
        public decimal o_weight { get; set; }
        public decimal o_uintprice { get; set; }
        public decimal o_price { get; set; }
        public Nullable<decimal> o_exchange { get; set; }
        public Nullable<decimal> o_exchange_pay { get; set; }
        public Nullable<decimal> o_uintpriceOld { get; set; }
        public Nullable<decimal> o_priceOld { get; set; }
        public Nullable<int> o_amountOld { get; set; }
        public Nullable<decimal> o_earnest { get; set; }
        public Nullable<decimal> o_balance { get; set; }
        public Nullable<decimal> o_freight { get; set; }
        public Nullable<bool> o_selfFreight { get; set; }
        public string o_freightmemo { get; set; }
        public string o_freightSheet { get; set; }
        public string o_freightcarrier { get; set; }
        public Nullable<System.Guid> o_freightcarrierId { get; set; }
        public string o_freightTruck { get; set; }
        public string o_freightDriver { get; set; }
        public string o_freightDriverPhone { get; set; }
        public Nullable<System.DateTime> o_freightArrive { get; set; }
        public string o_cif { get; set; }
        public string o_sh_sheng { get; set; }
        public string o_sh_shi { get; set; }
        public string o_sh_qu { get; set; }
        public string o_sh_jiedao { get; set; }
        public string o_sh_lxr { get; set; }
        public string o_sh_mob { get; set; }
        public string o_sh_pc { get; set; }
        public string o_sh_telqu { get; set; }
        public string o_sh_tel { get; set; }
        public string o_sh_telfen { get; set; }
        public string o_i_name { get; set; }
        public string o_i_taxcode { get; set; }
        public string o_i_bank { get; set; }
        public string o_i_bankno { get; set; }
        public string o_i_add { get; set; }
        public string o_i_tel { get; set; }
        public string o_memo { get; set; }
        public string o_shippic { get; set; }
        public string o_earnestpic { get; set; }
        public string o_balancepic { get; set; }
        public string o_lcpic { get; set; }
        public string o_reason { get; set; }
        public string o_recmsg { get; set; }
        public Nullable<int> o_stat { get; set; }
        public string o_statText { get; set; }
        public string o_statSeller { get; set; }
        public string o_statBuyer { get; set; }
        public Nullable<bool> o_tuijian { get; set; }
        public Nullable<bool> o_chk_agree_pay { get; set; }
        public Nullable<bool> o_chk_agree_agent { get; set; }
        public Nullable<bool> o_chk_qc { get; set; }
        public Nullable<System.Guid> o_qc_id { get; set; }
        public Nullable<System.Guid> o_pay_id { get; set; }
        public string o_lc_type { get; set; }
        public string o_lc_port { get; set; }
        public Nullable<int> o_lc_days { get; set; }
        public string o_lc_style { get; set; }
    }
}
