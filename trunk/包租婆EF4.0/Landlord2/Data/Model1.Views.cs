﻿





//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.239
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Data.Mapping.EntityViewGenerationAttribute(typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySetsE3712F4F02EB678FDBBC75F989C893294690A9647C168A59A808A0BF987C911F))]

namespace Edm_EntityMappingGeneratedViews
{
    
    
    /// <Summary>
    /// 此类型包含在设计时生成的 EntitySets 和 AssociationSets 的视图。
    /// </Summary>
    public sealed class ViewsForBaseEntitySetsE3712F4F02EB678FDBBC75F989C893294690A9647C168A59A808A0BF987C911F : System.Data.Mapping.EntityViewContainer
    {
        
        /// <Summary>
        /// 构造函数存储各区的视图，以及根据元数据和映射结束和视图生成的哈希值。
        /// </Summary>
        public ViewsForBaseEntitySetsE3712F4F02EB678FDBBC75F989C893294690A9647C168A59A808A0BF987C911F()
        {
            this.EdmEntityContainerName = "Entities";
            this.StoreEntityContainerName = "Landlord2ModelStoreContainer";
            this.HashOverMappingClosure = "f932df335059e4abf9ce1951d46f030600878eb09a3fae70ece3edc66eb6c928";
            this.HashOverAllExtentViews = "f909e4111f48fcda5671d857514135830d8febeb3c2dbe6da5d70c61e31b58c6";
            this.ViewCount = 24;
        }
        
        /// <Summary>
        /// 此方法返回给定索引的视图。
        /// </Summary>
        protected override System.Collections.Generic.KeyValuePair<string, string> GetViewAt(int index)
        {
            if ((index == 0))
            {
                return GetView0();
            }
            if ((index == 1))
            {
                return GetView1();
            }
            if ((index == 2))
            {
                return GetView2();
            }
            if ((index == 3))
            {
                return GetView3();
            }
            if ((index == 4))
            {
                return GetView4();
            }
            if ((index == 5))
            {
                return GetView5();
            }
            if ((index == 6))
            {
                return GetView6();
            }
            if ((index == 7))
            {
                return GetView7();
            }
            if ((index == 8))
            {
                return GetView8();
            }
            if ((index == 9))
            {
                return GetView9();
            }
            if ((index == 10))
            {
                return GetView10();
            }
            if ((index == 11))
            {
                return GetView11();
            }
            if ((index == 12))
            {
                return GetView12();
            }
            if ((index == 13))
            {
                return GetView13();
            }
            if ((index == 14))
            {
                return GetView14();
            }
            if ((index == 15))
            {
                return GetView15();
            }
            if ((index == 16))
            {
                return GetView16();
            }
            if ((index == 17))
            {
                return GetView17();
            }
            if ((index == 18))
            {
                return GetView18();
            }
            if ((index == 19))
            {
                return GetView19();
            }
            if ((index == 20))
            {
                return GetView20();
            }
            if ((index == 21))
            {
                return GetView21();
            }
            if ((index == 22))
            {
                return GetView22();
            }
            if ((index == 23))
            {
                return GetView23();
            }
            throw new System.IndexOutOfRangeException();
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.system 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView0()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.system", @"
    SELECT VALUE -- Constructing system
        [Landlord2Model.Store.system](T1.system_key, T1.system_value)
    FROM (
        SELECT 
            T.[key] AS system_key, 
            T.[value] AS system_value, 
            True AS _from0
        FROM Entities.system AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.system 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView1()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.system", @"
    SELECT VALUE -- Constructing system
        [Landlord2Model.system](T1.system_key, T1.system_value)
    FROM (
        SELECT 
            T.[key] AS system_key, 
            T.[value] AS system_value, 
            True AS _from0
        FROM Landlord2ModelStoreContainer.system AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.客房 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView2()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.客房", "\r\n    SELECT VALUE -- Constructing 客房\r\n        [Landlord2Model.Store.客房](T1.[客房_命" +
                    "名], T1.[客房_面积], T1.[客房_含厨房], T1.[客房_含卫生间], T1.[客房_租户], T1.[客房_联系地址], T1.[客房_身份证号" +
                    "], T1.[客房_电话1], T1.[客房_电话2], T1.[客房_期始], T1.[客房_期止], T1.[客房_月租金], T1.[客房_押金], T1" +
                    ".[客房_支付月数], T1.[客房_租赁协议照片1], T1.[客房_租赁协议照片2], T1.[客房_租赁协议照片3], T1.[客房_备注], T1.[客" +
                    "房_水始码], T1.[客房_电始码], T1.[客房_气始码], T1.[客房_月物业费], T1.[客房_月宽带费], T1.[客房_月厨房费], T1.[" +
                    "客房_中介费用], T1.[客房_ID], T1.[客房_源房ID])\r\n    FROM (\r\n        SELECT \r\n            T." +
                    "[命名] AS [客房_命名], \r\n            T.[面积] AS [客房_面积], \r\n            T.[含厨房] AS [客房_含" +
                    "厨房], \r\n            T.[含卫生间] AS [客房_含卫生间], \r\n            T.[租户] AS [客房_租户], \r\n   " +
                    "         T.[联系地址] AS [客房_联系地址], \r\n            T.[身份证号] AS [客房_身份证号], \r\n         " +
                    "   T.[电话1] AS [客房_电话1], \r\n            T.[电话2] AS [客房_电话2], \r\n            T.[期始] " +
                    "AS [客房_期始], \r\n            T.[期止] AS [客房_期止], \r\n            T.[月租金] AS [客房_月租金], " +
                    "\r\n            T.[押金] AS [客房_押金], \r\n            T.[支付月数] AS [客房_支付月数], \r\n        " +
                    "    T.[租赁协议照片1] AS [客房_租赁协议照片1], \r\n            T.[租赁协议照片2] AS [客房_租赁协议照片2], \r\n  " +
                    "          T.[租赁协议照片3] AS [客房_租赁协议照片3], \r\n            T.[备注] AS [客房_备注], \r\n      " +
                    "      T.[水始码] AS [客房_水始码], \r\n            T.[电始码] AS [客房_电始码], \r\n            T.[气" +
                    "始码] AS [客房_气始码], \r\n            T.[月物业费] AS [客房_月物业费], \r\n            T.[月宽带费] AS " +
                    "[客房_月宽带费], \r\n            T.[月厨房费] AS [客房_月厨房费], \r\n            T.[中介费用] AS [客房_中介" +
                    "费用], \r\n            T.ID AS [客房_ID], \r\n            T.[源房ID] AS [客房_源房ID], \r\n     " +
                    "       True AS _from0\r\n        FROM Entities.[客房] AS T\r\n    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.客房出租历史记录 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView3()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.客房出租历史记录", "\r\n    SELECT VALUE -- Constructing 客房出租历史记录\r\n        [Landlord2Model.Store.客房出租历史" +
                    "记录](T1.[客房出租历史记录_租户], T1.[客房出租历史记录_联系地址], T1.[客房出租历史记录_身份证号], T1.[客房出租历史记录_电话1]," +
                    " T1.[客房出租历史记录_电话2], T1.[客房出租历史记录_期始], T1.[客房出租历史记录_期止], T1.[客房出租历史记录_月租金], T1.[客" +
                    "房出租历史记录_押金], T1.[客房出租历史记录_支付月数], T1.[客房出租历史记录_备注], T1.[客房出租历史记录_客房ID], T1.[客房出租历" +
                    "史记录_ID], T1.[客房出租历史记录_租赁协议照片1], T1.[客房出租历史记录_租赁协议照片2], T1.[客房出租历史记录_租赁协议照片3], T1" +
                    ".[客房出租历史记录_水始码], T1.[客房出租历史记录_电始码], T1.[客房出租历史记录_气始码], T1.[客房出租历史记录_月物业费], T1.[客" +
                    "房出租历史记录_月宽带费], T1.[客房出租历史记录_月厨房费], T1.[客房出租历史记录_中介费用], T1.[客房出租历史记录_状态], T1.[客房出" +
                    "租历史记录_操作日期])\r\n    FROM (\r\n        SELECT \r\n            T.[租户] AS [客房出租历史记录_租户], " +
                    "\r\n            T.[联系地址] AS [客房出租历史记录_联系地址], \r\n            T.[身份证号] AS [客房出租历史记录_身" +
                    "份证号], \r\n            T.[电话1] AS [客房出租历史记录_电话1], \r\n            T.[电话2] AS [客房出租历史记" +
                    "录_电话2], \r\n            T.[期始] AS [客房出租历史记录_期始], \r\n            T.[期止] AS [客房出租历史记录" +
                    "_期止], \r\n            T.[月租金] AS [客房出租历史记录_月租金], \r\n            T.[押金] AS [客房出租历史记录" +
                    "_押金], \r\n            T.[支付月数] AS [客房出租历史记录_支付月数], \r\n            T.[备注] AS [客房出租历史" +
                    "记录_备注], \r\n            T.[客房ID] AS [客房出租历史记录_客房ID], \r\n            T.ID AS [客房出租历史" +
                    "记录_ID], \r\n            T.[租赁协议照片1] AS [客房出租历史记录_租赁协议照片1], \r\n            T.[租赁协议照片" +
                    "2] AS [客房出租历史记录_租赁协议照片2], \r\n            T.[租赁协议照片3] AS [客房出租历史记录_租赁协议照片3], \r\n   " +
                    "         T.[水始码] AS [客房出租历史记录_水始码], \r\n            T.[电始码] AS [客房出租历史记录_电始码], \r\n " +
                    "           T.[气始码] AS [客房出租历史记录_气始码], \r\n            T.[月物业费] AS [客房出租历史记录_月物业费]," +
                    " \r\n            T.[月宽带费] AS [客房出租历史记录_月宽带费], \r\n            T.[月厨房费] AS [客房出租历史记录_" +
                    "月厨房费], \r\n            T.[中介费用] AS [客房出租历史记录_中介费用], \r\n            T.[状态] AS [客房出租历" +
                    "史记录_状态], \r\n            T.[操作日期] AS [客房出租历史记录_操作日期], \r\n            True AS _from0" +
                    "\r\n        FROM Entities.[客房出租历史记录] AS T\r\n    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.客房租金明细 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView4()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.客房租金明细", @"
    SELECT VALUE -- Constructing 客房租金明细
        [Landlord2Model.Store.客房租金明细](T1.[客房租金明细_起付日期], T1.[客房租金明细_止付日期], T1.[客房租金明细_付款日期], T1.[客房租金明细_水止码], T1.[客房租金明细_电止码], T1.[客房租金明细_气止码], T1.[客房租金明细_应付金额], T1.[客房租金明细_实付金额], T1.[客房租金明细_付款人], T1.[客房租金明细_收款人], T1.[客房租金明细_备注], T1.[客房租金明细_客房ID], T1.[客房租金明细_ID])
    FROM (
        SELECT 
            T.[起付日期] AS [客房租金明细_起付日期], 
            T.[止付日期] AS [客房租金明细_止付日期], 
            T.[付款日期] AS [客房租金明细_付款日期], 
            T.[水止码] AS [客房租金明细_水止码], 
            T.[电止码] AS [客房租金明细_电止码], 
            T.[气止码] AS [客房租金明细_气止码], 
            T.[应付金额] AS [客房租金明细_应付金额], 
            T.[实付金额] AS [客房租金明细_实付金额], 
            T.[付款人] AS [客房租金明细_付款人], 
            T.[收款人] AS [客房租金明细_收款人], 
            T.[备注] AS [客房租金明细_备注], 
            T.[客房ID] AS [客房租金明细_客房ID], 
            T.ID AS [客房租金明细_ID], 
            True AS _from0
        FROM Entities.[客房租金明细] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.源房 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView5()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.源房", "\r\n    SELECT VALUE -- Constructing 源房\r\n        [Landlord2Model.Store.源房](T1.[源房_房" +
                    "名], T1.[源房_用途], T1.[源房_结构], T1.[源房_建筑面积], T1.[源房_室], T1.[源房_厅], T1.[源房_卫], T1.[源" +
                    "房_装修], T1.[源房_权证号], T1.[源房_房东], T1.[源房_联系地址], T1.[源房_身份证号], T1.[源房_电话1], T1.[源房_" +
                    "电话2], T1.[源房_押金], T1.[源房_支付月数], T1.[源房_租赁协议照片1], T1.[源房_租赁协议照片2], T1.[源房_租赁协议照片3" +
                    "], T1.[源房_备注], T1.[源房_月物业费], T1.[源房_水始码], T1.[源房_电始码], T1.[源房_气始码], T1.[源房_中介费用]" +
                    ", T1.[源房_月卫生费], T1.[源房_源房东银行卡], T1.[源房_水表编号], T1.[源房_电表编号], T1.[源房_气表编号], T1.[源房" +
                    "_水务代扣卫生费], T1.[源房_月宽带费], T1.[源房_阶梯水价], T1.[源房_阶梯电价], T1.[源房_气单价], T1.[源房_ID])\r\n " +
                    "   FROM (\r\n        SELECT \r\n            T.[房名] AS [源房_房名], \r\n            T.[用途] " +
                    "AS [源房_用途], \r\n            T.[结构] AS [源房_结构], \r\n            T.[建筑面积] AS [源房_建筑面积]" +
                    ", \r\n            T.[室] AS [源房_室], \r\n            T.[厅] AS [源房_厅], \r\n            T." +
                    "[卫] AS [源房_卫], \r\n            T.[装修] AS [源房_装修], \r\n            T.[权证号] AS [源房_权证号" +
                    "], \r\n            T.[房东] AS [源房_房东], \r\n            T.[联系地址] AS [源房_联系地址], \r\n     " +
                    "       T.[身份证号] AS [源房_身份证号], \r\n            T.[电话1] AS [源房_电话1], \r\n            T" +
                    ".[电话2] AS [源房_电话2], \r\n            T.[押金] AS [源房_押金], \r\n            T.[支付月数] AS [" +
                    "源房_支付月数], \r\n            T.[租赁协议照片1] AS [源房_租赁协议照片1], \r\n            T.[租赁协议照片2] A" +
                    "S [源房_租赁协议照片2], \r\n            T.[租赁协议照片3] AS [源房_租赁协议照片3], \r\n            T.[备注] " +
                    "AS [源房_备注], \r\n            T.[月物业费] AS [源房_月物业费], \r\n            T.[水始码] AS [源房_水始" +
                    "码], \r\n            T.[电始码] AS [源房_电始码], \r\n            T.[气始码] AS [源房_气始码], \r\n    " +
                    "        T.[中介费用] AS [源房_中介费用], \r\n            T.[月卫生费] AS [源房_月卫生费], \r\n          " +
                    "  T.[源房东银行卡] AS [源房_源房东银行卡], \r\n            T.[水表编号] AS [源房_水表编号], \r\n            " +
                    "T.[电表编号] AS [源房_电表编号], \r\n            T.[气表编号] AS [源房_气表编号], \r\n            T.[水务代" +
                    "扣卫生费] AS [源房_水务代扣卫生费], \r\n            T.[月宽带费] AS [源房_月宽带费], \r\n            T.[阶梯水" +
                    "价] AS [源房_阶梯水价], \r\n            T.[阶梯电价] AS [源房_阶梯电价], \r\n            T.[气单价] AS [" +
                    "源房_气单价], \r\n            T.ID AS [源房_ID], \r\n            True AS _from0\r\n        FR" +
                    "OM Entities.[源房] AS T\r\n    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.源房抄表 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView6()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.源房抄表", @"
    SELECT VALUE -- Constructing 源房抄表
        [Landlord2Model.Store.源房抄表](T1.[源房抄表_水止码], T1.[源房抄表_水账户余额], T1.[源房抄表_电止码], T1.[源房抄表_电账户余额], T1.[源房抄表_气表剩余字数], T1.[源房抄表_备注], T1.[源房抄表_源房ID], T1.[源房抄表_ID], T1.[源房抄表_抄表人], T1.[源房抄表_抄表时间])
    FROM (
        SELECT 
            T.[水止码] AS [源房抄表_水止码], 
            T.[水账户余额] AS [源房抄表_水账户余额], 
            T.[电止码] AS [源房抄表_电止码], 
            T.[电账户余额] AS [源房抄表_电账户余额], 
            T.[气表剩余字数] AS [源房抄表_气表剩余字数], 
            T.[备注] AS [源房抄表_备注], 
            T.[源房ID] AS [源房抄表_源房ID], 
            T.ID AS [源房抄表_ID], 
            T.[抄表人] AS [源房抄表_抄表人], 
            T.[抄表时间] AS [源房抄表_抄表时间], 
            True AS _from0
        FROM Entities.[源房抄表] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.源房缴费明细 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView7()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.源房缴费明细", @"
    SELECT VALUE -- Constructing 源房缴费明细
        [Landlord2Model.Store.源房缴费明细](T1.[源房缴费明细_缴费时间], T1.[源房缴费明细_缴费金额], T1.[源房缴费明细_期始], T1.[源房缴费明细_期止], T1.[源房缴费明细_付款人], T1.[源房缴费明细_收款人], T1.[源房缴费明细_备注], T1.[源房缴费明细_源房ID], T1.[源房缴费明细_缴费项], T1.[源房缴费明细_ID])
    FROM (
        SELECT 
            T.[缴费时间] AS [源房缴费明细_缴费时间], 
            T.[缴费金额] AS [源房缴费明细_缴费金额], 
            T.[期始] AS [源房缴费明细_期始], 
            T.[期止] AS [源房缴费明细_期止], 
            T.[付款人] AS [源房缴费明细_付款人], 
            T.[收款人] AS [源房缴费明细_收款人], 
            T.[备注] AS [源房缴费明细_备注], 
            T.[源房ID] AS [源房缴费明细_源房ID], 
            T.[缴费项] AS [源房缴费明细_缴费项], 
            T.ID AS [源房缴费明细_ID], 
            True AS _from0
        FROM Entities.[源房缴费明细] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.源房涨租协定 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView8()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.源房涨租协定", @"
    SELECT VALUE -- Constructing 源房涨租协定
        [Landlord2Model.Store.源房涨租协定](T1.[源房涨租协定_期始], T1.[源房涨租协定_期止], T1.[源房涨租协定_月租金], T1.[源房涨租协定_源房ID], T1.[源房涨租协定_ID])
    FROM (
        SELECT 
            T.[期始] AS [源房涨租协定_期始], 
            T.[期止] AS [源房涨租协定_期止], 
            T.[月租金] AS [源房涨租协定_月租金], 
            T.[源房ID] AS [源房涨租协定_源房ID], 
            T.ID AS [源房涨租协定_ID], 
            True AS _from0
        FROM Entities.[源房涨租协定] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.装修明细 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView9()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.装修明细", @"
    SELECT VALUE -- Constructing 装修明细
        [Landlord2Model.Store.装修明细](T1.[装修明细_日期], T1.[装修明细_项目名称], T1.[装修明细_规格], T1.[装修明细_数量], T1.[装修明细_单位], T1.[装修明细_单价], T1.[装修明细_购买地点], T1.[装修明细_备注], T1.[装修明细_源房ID], T1.[装修明细_装修分类], T1.[装修明细_ID])
    FROM (
        SELECT 
            T.[日期] AS [装修明细_日期], 
            T.[项目名称] AS [装修明细_项目名称], 
            T.[规格] AS [装修明细_规格], 
            T.[数量] AS [装修明细_数量], 
            T.[单位] AS [装修明细_单位], 
            T.[单价] AS [装修明细_单价], 
            T.[购买地点] AS [装修明细_购买地点], 
            T.[备注] AS [装修明细_备注], 
            T.[源房ID] AS [装修明细_源房ID], 
            T.[装修分类] AS [装修明细_装修分类], 
            T.ID AS [装修明细_ID], 
            True AS _from0
        FROM Entities.[装修明细] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.客房 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView10()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.客房", "\r\n    SELECT VALUE -- Constructing 客房\r\n        [Landlord2Model.客房](T1.[客房_命名], T1" +
                    ".[客房_面积], T1.[客房_含厨房], T1.[客房_含卫生间], T1.[客房_租户], T1.[客房_联系地址], T1.[客房_身份证号], T1." +
                    "[客房_电话1], T1.[客房_电话2], T1.[客房_期始], T1.[客房_期止], T1.[客房_月租金], T1.[客房_押金], T1.[客房_支" +
                    "付月数], T1.[客房_租赁协议照片1], T1.[客房_租赁协议照片2], T1.[客房_租赁协议照片3], T1.[客房_备注], T1.[客房_水始码]" +
                    ", T1.[客房_电始码], T1.[客房_气始码], T1.[客房_月物业费], T1.[客房_月宽带费], T1.[客房_月厨房费], T1.[客房_中介费" +
                    "用], T1.[客房_ID], T1.[客房_源房ID])\r\n    FROM (\r\n        SELECT \r\n            T.[命名] A" +
                    "S [客房_命名], \r\n            T.[面积] AS [客房_面积], \r\n            T.[含厨房] AS [客房_含厨房], \r" +
                    "\n            T.[含卫生间] AS [客房_含卫生间], \r\n            T.[租户] AS [客房_租户], \r\n         " +
                    "   T.[联系地址] AS [客房_联系地址], \r\n            T.[身份证号] AS [客房_身份证号], \r\n            T.[" +
                    "电话1] AS [客房_电话1], \r\n            T.[电话2] AS [客房_电话2], \r\n            T.[期始] AS [客房" +
                    "_期始], \r\n            T.[期止] AS [客房_期止], \r\n            T.[月租金] AS [客房_月租金], \r\n    " +
                    "        T.[押金] AS [客房_押金], \r\n            T.[支付月数] AS [客房_支付月数], \r\n            T." +
                    "[租赁协议照片1] AS [客房_租赁协议照片1], \r\n            T.[租赁协议照片2] AS [客房_租赁协议照片2], \r\n        " +
                    "    T.[租赁协议照片3] AS [客房_租赁协议照片3], \r\n            T.[备注] AS [客房_备注], \r\n            " +
                    "T.[水始码] AS [客房_水始码], \r\n            T.[电始码] AS [客房_电始码], \r\n            T.[气始码] AS" +
                    " [客房_气始码], \r\n            T.[月物业费] AS [客房_月物业费], \r\n            T.[月宽带费] AS [客房_月宽" +
                    "带费], \r\n            T.[月厨房费] AS [客房_月厨房费], \r\n            T.[中介费用] AS [客房_中介费用], \r" +
                    "\n            T.ID AS [客房_ID], \r\n            T.[源房ID] AS [客房_源房ID], \r\n           " +
                    " True AS _from0\r\n        FROM Landlord2ModelStoreContainer.[客房] AS T\r\n    ) AS T" +
                    "1");
        }
        
        /// <Summary>
        /// 返回 Entities.客房出租历史记录 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView11()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.客房出租历史记录", "\r\n    SELECT VALUE -- Constructing 客房出租历史记录\r\n        [Landlord2Model.客房出租历史记录](T1" +
                    ".[客房出租历史记录_租户], T1.[客房出租历史记录_联系地址], T1.[客房出租历史记录_身份证号], T1.[客房出租历史记录_电话1], T1.[客" +
                    "房出租历史记录_电话2], T1.[客房出租历史记录_期始], T1.[客房出租历史记录_期止], T1.[客房出租历史记录_月租金], T1.[客房出租历史记" +
                    "录_押金], T1.[客房出租历史记录_支付月数], T1.[客房出租历史记录_备注], T1.[客房出租历史记录_客房ID], T1.[客房出租历史记录_ID" +
                    "], T1.[客房出租历史记录_租赁协议照片1], T1.[客房出租历史记录_租赁协议照片2], T1.[客房出租历史记录_租赁协议照片3], T1.[客房出租" +
                    "历史记录_水始码], T1.[客房出租历史记录_电始码], T1.[客房出租历史记录_气始码], T1.[客房出租历史记录_月物业费], T1.[客房出租历史记" +
                    "录_月宽带费], T1.[客房出租历史记录_月厨房费], T1.[客房出租历史记录_中介费用], T1.[客房出租历史记录_状态], T1.[客房出租历史记录_" +
                    "操作日期])\r\n    FROM (\r\n        SELECT \r\n            T.[租户] AS [客房出租历史记录_租户], \r\n    " +
                    "        T.[联系地址] AS [客房出租历史记录_联系地址], \r\n            T.[身份证号] AS [客房出租历史记录_身份证号], " +
                    "\r\n            T.[电话1] AS [客房出租历史记录_电话1], \r\n            T.[电话2] AS [客房出租历史记录_电话2]" +
                    ", \r\n            T.[期始] AS [客房出租历史记录_期始], \r\n            T.[期止] AS [客房出租历史记录_期止], " +
                    "\r\n            T.[月租金] AS [客房出租历史记录_月租金], \r\n            T.[押金] AS [客房出租历史记录_押金], " +
                    "\r\n            T.[支付月数] AS [客房出租历史记录_支付月数], \r\n            T.[备注] AS [客房出租历史记录_备注]" +
                    ", \r\n            T.[客房ID] AS [客房出租历史记录_客房ID], \r\n            T.ID AS [客房出租历史记录_ID]" +
                    ", \r\n            T.[租赁协议照片1] AS [客房出租历史记录_租赁协议照片1], \r\n            T.[租赁协议照片2] AS " +
                    "[客房出租历史记录_租赁协议照片2], \r\n            T.[租赁协议照片3] AS [客房出租历史记录_租赁协议照片3], \r\n         " +
                    "   T.[水始码] AS [客房出租历史记录_水始码], \r\n            T.[电始码] AS [客房出租历史记录_电始码], \r\n       " +
                    "     T.[气始码] AS [客房出租历史记录_气始码], \r\n            T.[月物业费] AS [客房出租历史记录_月物业费], \r\n   " +
                    "         T.[月宽带费] AS [客房出租历史记录_月宽带费], \r\n            T.[月厨房费] AS [客房出租历史记录_月厨房费]," +
                    " \r\n            T.[中介费用] AS [客房出租历史记录_中介费用], \r\n            T.[状态] AS [客房出租历史记录_状态" +
                    "], \r\n            T.[操作日期] AS [客房出租历史记录_操作日期], \r\n            True AS _from0\r\n    " +
                    "    FROM Landlord2ModelStoreContainer.[客房出租历史记录] AS T\r\n    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.客房租金明细 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView12()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.客房租金明细", @"
    SELECT VALUE -- Constructing 客房租金明细
        [Landlord2Model.客房租金明细](T1.[客房租金明细_起付日期], T1.[客房租金明细_止付日期], T1.[客房租金明细_付款日期], T1.[客房租金明细_水止码], T1.[客房租金明细_电止码], T1.[客房租金明细_气止码], T1.[客房租金明细_应付金额], T1.[客房租金明细_实付金额], T1.[客房租金明细_付款人], T1.[客房租金明细_收款人], T1.[客房租金明细_备注], T1.[客房租金明细_客房ID], T1.[客房租金明细_ID])
    FROM (
        SELECT 
            T.[起付日期] AS [客房租金明细_起付日期], 
            T.[止付日期] AS [客房租金明细_止付日期], 
            T.[付款日期] AS [客房租金明细_付款日期], 
            T.[水止码] AS [客房租金明细_水止码], 
            T.[电止码] AS [客房租金明细_电止码], 
            T.[气止码] AS [客房租金明细_气止码], 
            T.[应付金额] AS [客房租金明细_应付金额], 
            T.[实付金额] AS [客房租金明细_实付金额], 
            T.[付款人] AS [客房租金明细_付款人], 
            T.[收款人] AS [客房租金明细_收款人], 
            T.[备注] AS [客房租金明细_备注], 
            T.[客房ID] AS [客房租金明细_客房ID], 
            T.ID AS [客房租金明细_ID], 
            True AS _from0
        FROM Landlord2ModelStoreContainer.[客房租金明细] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.源房 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView13()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.源房", "\r\n    SELECT VALUE -- Constructing 源房\r\n        [Landlord2Model.源房](T1.[源房_房名], T1" +
                    ".[源房_用途], T1.[源房_结构], T1.[源房_建筑面积], T1.[源房_室], T1.[源房_厅], T1.[源房_卫], T1.[源房_装修]," +
                    " T1.[源房_权证号], T1.[源房_房东], T1.[源房_联系地址], T1.[源房_身份证号], T1.[源房_电话1], T1.[源房_电话2], " +
                    "T1.[源房_押金], T1.[源房_支付月数], T1.[源房_租赁协议照片1], T1.[源房_租赁协议照片2], T1.[源房_租赁协议照片3], T1." +
                    "[源房_备注], T1.[源房_月物业费], T1.[源房_水始码], T1.[源房_电始码], T1.[源房_气始码], T1.[源房_中介费用], T1.[" +
                    "源房_月卫生费], T1.[源房_源房东银行卡], T1.[源房_水表编号], T1.[源房_电表编号], T1.[源房_气表编号], T1.[源房_水务代扣卫" +
                    "生费], T1.[源房_月宽带费], T1.[源房_阶梯水价], T1.[源房_阶梯电价], T1.[源房_气单价], T1.[源房_ID])\r\n    FRO" +
                    "M (\r\n        SELECT \r\n            T.[房名] AS [源房_房名], \r\n            T.[用途] AS [源房" +
                    "_用途], \r\n            T.[结构] AS [源房_结构], \r\n            T.[建筑面积] AS [源房_建筑面积], \r\n  " +
                    "          T.[室] AS [源房_室], \r\n            T.[厅] AS [源房_厅], \r\n            T.[卫] AS" +
                    " [源房_卫], \r\n            T.[装修] AS [源房_装修], \r\n            T.[权证号] AS [源房_权证号], \r\n " +
                    "           T.[房东] AS [源房_房东], \r\n            T.[联系地址] AS [源房_联系地址], \r\n           " +
                    " T.[身份证号] AS [源房_身份证号], \r\n            T.[电话1] AS [源房_电话1], \r\n            T.[电话2]" +
                    " AS [源房_电话2], \r\n            T.[押金] AS [源房_押金], \r\n            T.[支付月数] AS [源房_支付月" +
                    "数], \r\n            T.[租赁协议照片1] AS [源房_租赁协议照片1], \r\n            T.[租赁协议照片2] AS [源房_" +
                    "租赁协议照片2], \r\n            T.[租赁协议照片3] AS [源房_租赁协议照片3], \r\n            T.[备注] AS [源房" +
                    "_备注], \r\n            T.[月物业费] AS [源房_月物业费], \r\n            T.[水始码] AS [源房_水始码], \r\n" +
                    "            T.[电始码] AS [源房_电始码], \r\n            T.[气始码] AS [源房_气始码], \r\n          " +
                    "  T.[中介费用] AS [源房_中介费用], \r\n            T.[月卫生费] AS [源房_月卫生费], \r\n            T.[源" +
                    "房东银行卡] AS [源房_源房东银行卡], \r\n            T.[水表编号] AS [源房_水表编号], \r\n            T.[电表编" +
                    "号] AS [源房_电表编号], \r\n            T.[气表编号] AS [源房_气表编号], \r\n            T.[水务代扣卫生费] " +
                    "AS [源房_水务代扣卫生费], \r\n            T.[月宽带费] AS [源房_月宽带费], \r\n            T.[阶梯水价] AS " +
                    "[源房_阶梯水价], \r\n            T.[阶梯电价] AS [源房_阶梯电价], \r\n            T.[气单价] AS [源房_气单价" +
                    "], \r\n            T.ID AS [源房_ID], \r\n            True AS _from0\r\n        FROM Lan" +
                    "dlord2ModelStoreContainer.[源房] AS T\r\n    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.源房抄表 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView14()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.源房抄表", @"
    SELECT VALUE -- Constructing 源房抄表
        [Landlord2Model.源房抄表](T1.[源房抄表_水止码], T1.[源房抄表_水账户余额], T1.[源房抄表_电止码], T1.[源房抄表_电账户余额], T1.[源房抄表_气表剩余字数], T1.[源房抄表_备注], T1.[源房抄表_源房ID], T1.[源房抄表_ID], T1.[源房抄表_抄表人], T1.[源房抄表_抄表时间])
    FROM (
        SELECT 
            T.[水止码] AS [源房抄表_水止码], 
            T.[水账户余额] AS [源房抄表_水账户余额], 
            T.[电止码] AS [源房抄表_电止码], 
            T.[电账户余额] AS [源房抄表_电账户余额], 
            T.[气表剩余字数] AS [源房抄表_气表剩余字数], 
            T.[备注] AS [源房抄表_备注], 
            T.[源房ID] AS [源房抄表_源房ID], 
            T.ID AS [源房抄表_ID], 
            T.[抄表人] AS [源房抄表_抄表人], 
            T.[抄表时间] AS [源房抄表_抄表时间], 
            True AS _from0
        FROM Landlord2ModelStoreContainer.[源房抄表] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.源房缴费明细 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView15()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.源房缴费明细", @"
    SELECT VALUE -- Constructing 源房缴费明细
        [Landlord2Model.源房缴费明细](T1.[源房缴费明细_缴费时间], T1.[源房缴费明细_缴费金额], T1.[源房缴费明细_期始], T1.[源房缴费明细_期止], T1.[源房缴费明细_付款人], T1.[源房缴费明细_收款人], T1.[源房缴费明细_备注], T1.[源房缴费明细_源房ID], T1.[源房缴费明细_缴费项], T1.[源房缴费明细_ID])
    FROM (
        SELECT 
            T.[缴费时间] AS [源房缴费明细_缴费时间], 
            T.[缴费金额] AS [源房缴费明细_缴费金额], 
            T.[期始] AS [源房缴费明细_期始], 
            T.[期止] AS [源房缴费明细_期止], 
            T.[付款人] AS [源房缴费明细_付款人], 
            T.[收款人] AS [源房缴费明细_收款人], 
            T.[备注] AS [源房缴费明细_备注], 
            T.[源房ID] AS [源房缴费明细_源房ID], 
            T.[缴费项] AS [源房缴费明细_缴费项], 
            T.ID AS [源房缴费明细_ID], 
            True AS _from0
        FROM Landlord2ModelStoreContainer.[源房缴费明细] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.源房涨租协定 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView16()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.源房涨租协定", @"
    SELECT VALUE -- Constructing 源房涨租协定
        [Landlord2Model.源房涨租协定](T1.[源房涨租协定_期始], T1.[源房涨租协定_期止], T1.[源房涨租协定_月租金], T1.[源房涨租协定_源房ID], T1.[源房涨租协定_ID])
    FROM (
        SELECT 
            T.[期始] AS [源房涨租协定_期始], 
            T.[期止] AS [源房涨租协定_期止], 
            T.[月租金] AS [源房涨租协定_月租金], 
            T.[源房ID] AS [源房涨租协定_源房ID], 
            T.ID AS [源房涨租协定_ID], 
            True AS _from0
        FROM Landlord2ModelStoreContainer.[源房涨租协定] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.装修明细 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView17()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.装修明细", @"
    SELECT VALUE -- Constructing 装修明细
        [Landlord2Model.装修明细](T1.[装修明细_日期], T1.[装修明细_项目名称], T1.[装修明细_规格], T1.[装修明细_数量], T1.[装修明细_单位], T1.[装修明细_单价], T1.[装修明细_购买地点], T1.[装修明细_备注], T1.[装修明细_源房ID], T1.[装修明细_装修分类], T1.[装修明细_ID])
    FROM (
        SELECT 
            T.[日期] AS [装修明细_日期], 
            T.[项目名称] AS [装修明细_项目名称], 
            T.[规格] AS [装修明细_规格], 
            T.[数量] AS [装修明细_数量], 
            T.[单位] AS [装修明细_单位], 
            T.[单价] AS [装修明细_单价], 
            T.[购买地点] AS [装修明细_购买地点], 
            T.[备注] AS [装修明细_备注], 
            T.[源房ID] AS [装修明细_源房ID], 
            T.[装修分类] AS [装修明细_装修分类], 
            T.ID AS [装修明细_ID], 
            True AS _from0
        FROM Landlord2ModelStoreContainer.[装修明细] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.日常损耗 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView18()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.日常损耗", @"
    SELECT VALUE -- Constructing 日常损耗
        [Landlord2Model.Store.日常损耗](T1.[日常损耗_源房ID], T1.[日常损耗_客房ID], T1.[日常损耗_项目], T1.[日常损耗_支出金额], T1.[日常损耗_支出日期], T1.[日常损耗_备注], T1.[日常损耗_ID])
    FROM (
        SELECT 
            T.[源房ID] AS [日常损耗_源房ID], 
            T.[客房ID] AS [日常损耗_客房ID], 
            T.[项目] AS [日常损耗_项目], 
            T.[支出金额] AS [日常损耗_支出金额], 
            T.[支出日期] AS [日常损耗_支出日期], 
            T.[备注] AS [日常损耗_备注], 
            T.ID AS [日常损耗_ID], 
            True AS _from0
        FROM Entities.[日常损耗] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.日常损耗 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView19()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.日常损耗", @"
    SELECT VALUE -- Constructing 日常损耗
        [Landlord2Model.日常损耗](T1.[日常损耗_源房ID], T1.[日常损耗_客房ID], T1.[日常损耗_项目], T1.[日常损耗_支出金额], T1.[日常损耗_支出日期], T1.[日常损耗_备注], T1.[日常损耗_ID])
    FROM (
        SELECT 
            T.[源房ID] AS [日常损耗_源房ID], 
            T.[客房ID] AS [日常损耗_客房ID], 
            T.[项目] AS [日常损耗_项目], 
            T.[支出金额] AS [日常损耗_支出金额], 
            T.[支出日期] AS [日常损耗_支出日期], 
            T.[备注] AS [日常损耗_备注], 
            T.ID AS [日常损耗_ID], 
            True AS _from0
        FROM Landlord2ModelStoreContainer.[日常损耗] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.提醒 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView20()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.提醒", @"
    SELECT VALUE -- Constructing 提醒
        [Landlord2Model.Store.提醒](T1.[提醒_提醒时间], T1.[提醒_事项], T1.[提醒_已完成], T1.[提醒_创建日期], T1.[提醒_完成日期], T1.[提醒_客房ID], T1.[提醒_源房ID], T1.[提醒_ID])
    FROM (
        SELECT 
            T.[提醒时间] AS [提醒_提醒时间], 
            T.[事项] AS [提醒_事项], 
            T.[已完成] AS [提醒_已完成], 
            T.[创建日期] AS [提醒_创建日期], 
            T.[完成日期] AS [提醒_完成日期], 
            T.[客房ID] AS [提醒_客房ID], 
            T.[源房ID] AS [提醒_源房ID], 
            T.ID AS [提醒_ID], 
            True AS _from0
        FROM Entities.[提醒] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.提醒 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView21()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.提醒", @"
    SELECT VALUE -- Constructing 提醒
        [Landlord2Model.提醒](T1.[提醒_提醒时间], T1.[提醒_事项], T1.[提醒_已完成], T1.[提醒_创建日期], T1.[提醒_完成日期], T1.[提醒_客房ID], T1.[提醒_源房ID], T1.[提醒_ID])
    FROM (
        SELECT 
            T.[提醒时间] AS [提醒_提醒时间], 
            T.[事项] AS [提醒_事项], 
            T.[已完成] AS [提醒_已完成], 
            T.[创建日期] AS [提醒_创建日期], 
            T.[完成日期] AS [提醒_完成日期], 
            T.[客房ID] AS [提醒_客房ID], 
            T.[源房ID] AS [提醒_源房ID], 
            T.ID AS [提醒_ID], 
            True AS _from0
        FROM Landlord2ModelStoreContainer.[提醒] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Landlord2ModelStoreContainer.装修分类 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView22()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Landlord2ModelStoreContainer.装修分类", @"
    SELECT VALUE -- Constructing 装修分类
        [Landlord2Model.Store.装修分类](T1.[装修分类_类别], T1.[装修分类_ID])
    FROM (
        SELECT 
            T.[类别] AS [装修分类_类别], 
            T.ID AS [装修分类_ID], 
            True AS _from0
        FROM Entities.[装修分类] AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// 返回 Entities.装修分类 的视图
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView23()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Entities.装修分类", @"
    SELECT VALUE -- Constructing 装修分类
        [Landlord2Model.装修分类](T1.[装修分类_类别], T1.[装修分类_ID])
    FROM (
        SELECT 
            T.[类别] AS [装修分类_类别], 
            T.ID AS [装修分类_ID], 
            True AS _from0
        FROM Landlord2ModelStoreContainer.[装修分类] AS T
    ) AS T1");
        }
    }
}


