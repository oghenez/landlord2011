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

        //重载ToString方法。
        public override string ToString()
        {
            return this.房名;
        }

        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 查询所有
        /// </summary>
        static readonly Func<Entities, ObjectQuery<源房>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<源房>>(
            (context) => (ObjectQuery<源房>)context.源房.
                OrderByDescending(m => m.源房涨租协定.Min(n => n.期始)));
        /// <summary>
        /// 预编译查询0 -- 查询所有源房，最近签约的排最前
        /// </summary>
        public static ObjectQuery<源房> GetYF(MyContext context)
        {
            return compiledQuery0.Invoke(context);
        }

        /// <summary>
        /// 预编译查询1 -- 查询非历史源房
        /// </summary>
        static readonly Func<Entities, ObjectQuery<源房>> compiledQuery1 =
            CompiledQuery.Compile<Entities, ObjectQuery<源房>>(
            (context) => (ObjectQuery<源房>)context.源房.
                Where(m => m.源房涨租协定.Max(n => n.期止) > DateTime.Now).
                OrderByDescending(m => m.源房涨租协定.Min(n => n.期始)));
        /// <summary>
        /// 预编译查询1 -- 查询非历史源房，最近签约的排最前
        /// </summary>
        public static ObjectQuery<源房> GetYF_NoHistory(MyContext context)
        {
            return compiledQuery1.Invoke(context);
        }

        /// <summary>
        /// 预编译查询2 -- 查询历史源房
        /// </summary>
        static readonly Func<Entities, ObjectQuery<源房>> compiledQuery2 =
            CompiledQuery.Compile<Entities, ObjectQuery<源房>>(
            (context) => (ObjectQuery<源房>)context.源房.
                Where(m => m.源房涨租协定.Max(n => n.期止) <= DateTime.Now).
                OrderByDescending(m => m.源房涨租协定.Min(n => n.期始)));
        /// <summary>
        /// 预编译查询2 -- 查询历史源房，最近签约的排最前
        /// </summary>
        public static ObjectQuery<源房> GetYF_History(MyContext context)
        {
            return compiledQuery2.Invoke(context);
        }
        #endregion
    }
}
