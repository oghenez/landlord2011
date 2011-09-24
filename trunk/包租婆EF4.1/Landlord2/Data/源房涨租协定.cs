using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////

    public partial class 源房涨租协定
    {
        public 源房涨租协定()
        {
            this.ID = Guid.NewGuid();
        }

        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 根据源房ID过滤
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<源房涨租协定>> compiledQuery0 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<源房涨租协定>>(
            (context, guid) => (ObjectQuery<源房涨租协定>)context.源房涨租协定.
                Where(m => m.源房ID == guid).
                OrderBy(n=>n.期始));
        /// <summary>
        /// 预编译查询0 -- 根据源房ID过滤，按期始时间排序
        /// </summary>
        public static ObjectQuery<源房涨租协定> GetByYFid(Guid 源房ID)
        {
            return compiledQuery0.Invoke(Main.context, 源房ID);
        }
        #endregion
    }
}
