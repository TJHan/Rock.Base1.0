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
    
    public partial class v_Qc
    {
        public long q_id { get; set; }
        public Nullable<System.Guid> q_guid { get; set; }
        public Nullable<System.Guid> q_flowid { get; set; }
        public System.DateTime q_redate { get; set; }
        public Nullable<System.DateTime> q_checkDate { get; set; }
        public System.Guid q_order_id { get; set; }
        public string q_order_code { get; set; }
        public string q_checker { get; set; }
        public string q_checker_eng { get; set; }
        public Nullable<System.Guid> q_checker_guid { get; set; }
        public string q_check_lxr { get; set; }
        public string q_check_lxr_eng { get; set; }
        public string q_check_tel { get; set; }
        public string q_check_mob { get; set; }
        public string q_check_add { get; set; }
        public string q_check_add_eng { get; set; }
        public string q_check_fw { get; set; }
        public string q_region { get; set; }
        public string q_enterprise { get; set; }
        public string q_enterprise_eng { get; set; }
        public System.Guid q_ent_guid { get; set; }
        public string q_checkadd { get; set; }
        public string q_lianxiren { get; set; }
        public string q_tel { get; set; }
        public Nullable<bool> q_result { get; set; }
        public string q_status { get; set; }
        public string q_reason { get; set; }
        public Nullable<decimal> q_ac { get; set; }
        public Nullable<decimal> q_cv { get; set; }
        public Nullable<decimal> q_scv { get; set; }
        public Nullable<decimal> q_ipi { get; set; }
        public Nullable<decimal> q_tpi { get; set; }
        public Nullable<decimal> q_hcl { get; set; }
        public Nullable<decimal> q_u { get; set; }
        public Nullable<decimal> q_thin { get; set; }
        public Nullable<decimal> q_thick { get; set; }
        public Nullable<decimal> q_clsp { get; set; }
        public Nullable<decimal> q_sys { get; set; }
        public Nullable<decimal> q_neps200 { get; set; }
        public Nullable<decimal> q_neps280 { get; set; }
        public Nullable<bool> q_finish { get; set; }
        public Nullable<decimal> q_s_ac { get; set; }
        public Nullable<decimal> q_s_u { get; set; }
        public Nullable<decimal> q_s_clsp { get; set; }
        public Nullable<decimal> q_s_sys { get; set; }
        public Nullable<decimal> q_d_ac { get; set; }
        public Nullable<decimal> q_d_u { get; set; }
        public Nullable<decimal> q_d_clsp { get; set; }
        public Nullable<decimal> q_d_sys { get; set; }
        public Nullable<decimal> q_d_cv { get; set; }
        public Nullable<decimal> q_d_thin { get; set; }
        public Nullable<decimal> q_d_scv { get; set; }
        public Nullable<decimal> q_d_thick { get; set; }
        public Nullable<decimal> q_d_ipi { get; set; }
        public Nullable<decimal> q_d_tpi { get; set; }
        public Nullable<decimal> q_d_neps200 { get; set; }
        public Nullable<decimal> q_d_neps280 { get; set; }
        public Nullable<bool> q_m_ac { get; set; }
        public Nullable<bool> q_m_u { get; set; }
        public Nullable<bool> q_m_clsp { get; set; }
        public Nullable<bool> q_m_sys { get; set; }
        public Nullable<int> q_status_index { get; set; }
        public int p_id { get; set; }
        public Nullable<System.Guid> p_orderid { get; set; }
        public Nullable<System.Guid> p_guid { get; set; }
        public Nullable<System.DateTime> p_indate { get; set; }
        public string p_inputer { get; set; }
        public System.Guid p_inputerid { get; set; }
        public string p_company { get; set; }
        public string p_companyEng { get; set; }
        public System.Guid p_companyid { get; set; }
        public string p_lxr { get; set; }
        public string p_lxrEng { get; set; }
        public string p_pic { get; set; }
        public Nullable<int> p_clk { get; set; }
        public Nullable<int> p_buyCount { get; set; }
        public Nullable<int> p_type_id { get; set; }
        public string p_type { get; set; }
        public string p_chengfen { get; set; }
        public string p_Chandi { get; set; }
        public string p_shipPort { get; set; }
        public string p_Brand { get; set; }
        public string p_Yongtu { get; set; }
        public string p_shumiangy { get; set; }
        public string p_chengshashebei { get; set; }
        public string p_shazhi { get; set; }
        public string p_gushu { get; set; }
        public string p_class { get; set; }
        public string p_ActualCount { get; set; }
        public string p_CountCV { get; set; }
        public string p_CLSP { get; set; }
        public string p_StengthCV { get; set; }
        public string p_syscn { get; set; }
        public string p_TPI { get; set; }
        public string p_U { get; set; }
        public string p_Thin { get; set; }
        public string p_Thick { get; set; }
        public string p_IPI { get; set; }
        public string p_mj200 { get; set; }
        public string p_mj280 { get; set; }
        public Nullable<decimal> p_Price { get; set; }
        public string p_PriceUnit { get; set; }
        public System.DateTime p_youxiaoDate { get; set; }
        public string p_zhuangchuanDate { get; set; }
        public Nullable<decimal> p_packs { get; set; }
        public Nullable<int> p_packnum { get; set; }
        public Nullable<int> p_packe { get; set; }
        public Nullable<decimal> p_gonghuos { get; set; }
        public string p_xiang { get; set; }
        public string p_guitype { get; set; }
        public Nullable<int> p_gonghuoe { get; set; }
        public string p_memo { get; set; }
        public Nullable<int> p_sort { get; set; }
        public Nullable<int> p_tuijian { get; set; }
        public Nullable<byte> p_stat { get; set; }
        public string p_statText { get; set; }
        public string p_statReason { get; set; }
        public string p_sh_sheng { get; set; }
        public string p_sh_shi { get; set; }
        public string p_sh_qu { get; set; }
        public string p_sh_jiedao { get; set; }
        public string p_sh_lxr { get; set; }
        public string p_sh_mob { get; set; }
        public string p_sh_pc { get; set; }
        public string p_sh_telqu { get; set; }
        public string p_sh_tel { get; set; }
        public string p_sh_telfen { get; set; }
        public string p_fahuodi { get; set; }
        public Nullable<decimal> p_yufukuan { get; set; }
        public Nullable<bool> p_hanshui { get; set; }
        public Nullable<decimal> p_netweight { get; set; }
        public Nullable<decimal> p_boxweight { get; set; }
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
