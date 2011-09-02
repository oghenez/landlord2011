using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////


    public partial class 源房
    {
        public 源房()
        {
            this.ID = Guid.NewGuid();
        }

        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 查询所有
        /// </summary>
        static readonly Func<Entities, ObjectQuery<源房>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<源房>>(
            (context) => context.源房);
        /// <summary>
        /// 预编译查询0 -- 查询所有源房
        /// </summary>
        public static ObjectQuery<源房> GetYF()
        {
            return compiledQuery0.Invoke(Main.context);
        }

        /// <summary>
        /// 预编译查询1 -- 查询非历史源房
        /// </summary>
        static readonly Func<Entities, ObjectQuery<源房>> compiledQuery1 =
            CompiledQuery.Compile<Entities, ObjectQuery<源房>>(
            (context) => (ObjectQuery<源房>)context.源房.Where(m => m.源房涨租协定.Max(n => n.期止) > DateTime.Now));
        /// <summary>
        /// 预编译查询1 -- 查询非历史源房
        /// </summary>
        public static ObjectQuery<源房> GetYF_NoHistory()
        {
            return compiledQuery1.Invoke(Main.context);
        }

        /// <summary>
        /// 预编译查询1 -- 查询历史源房
        /// </summary>
        static readonly Func<Entities, ObjectQuery<源房>> compiledQuery2 =
            CompiledQuery.Compile<Entities, ObjectQuery<源房>>(
            (context) => (ObjectQuery<源房>)context.源房.Where(m => m.源房涨租协定.Max(n => n.期止) <= DateTime.Now));
        /// <summary>
        /// 预编译查询0 -- 查询历史源房
        /// </summary>
        public static ObjectQuery<源房> GetYF_History()
        {
            return compiledQuery2.Invoke(Main.context);
        }
        #endregion
    }
}
