using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////

    public partial class 源房缴费明细
    {
        public 源房缴费明细()
        {
            this.ID = Guid.NewGuid();
        }


        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 查询所有
        /// </summary>
        static readonly Func<Entities, ObjectQuery<源房缴费明细>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<源房缴费明细>>(
            (context) => context.源房缴费明细);
        /// <summary>
        /// 预编译查询0 -- 查询所有源房缴费明细
        /// </summary>
        public static ObjectQuery<源房缴费明细> GetPayDetails()
        {
            return compiledQuery0.Invoke(Main.context);
        }

        /// <summary>
        /// 预编译查询1 -- 根据源房ID和缴费项2个条件过滤
        /// </summary>
        static readonly Func<Entities, Guid, string, ObjectQuery<源房缴费明细>> compiledQuery1 =
            CompiledQuery.Compile<Entities, Guid, string, ObjectQuery<源房缴费明细>>(
            (context, guid, payItem) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.Where(m => m.源房ID == guid && m.缴费项 == payItem));
        /// <summary>
        /// 预编译查询1 -- 根据源房ID和缴费项2个条件过滤
        /// </summary>
        public static ObjectQuery<源房缴费明细> GetPayDetails(Guid guid, string 缴费项)
        {
            return compiledQuery1.Invoke(Main.context, guid, 缴费项);
        }

        /// <summary>
        /// 预编译查询2 -- 根据源房ID过滤
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<源房缴费明细>> compiledQuery2 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<源房缴费明细>>(
            (context, guid) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.Where(m => m.源房ID == guid));
        /// <summary>
        /// 预编译查询2 -- 根据源房ID过滤
        /// </summary>
        public static ObjectQuery<源房缴费明细> GetPayDetails(Guid guid)
        {
            return compiledQuery2.Invoke(Main.context, guid);
        }

        /// <summary>
        /// 预编译查询3 -- 根据缴费项过滤
        /// </summary>
        static readonly Func<Entities, string, ObjectQuery<源房缴费明细>> compiledQuery3 =
            CompiledQuery.Compile<Entities, string, ObjectQuery<源房缴费明细>>(
            (context, payItem) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.Where(m => m.缴费项 == payItem));
        /// <summary>
        /// 预编译查询3 -- 根据缴费项过滤
        /// </summary>
        public static ObjectQuery<源房缴费明细> GetPayDetails(string 缴费项)
        {
            return compiledQuery3.Invoke(Main.context, 缴费项);
        }
        #endregion

    }
}
