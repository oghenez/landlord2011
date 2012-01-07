using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////


    public partial class 提醒
    {
        public 提醒()
        {
            this.ID = Guid.NewGuid();
            this.提醒时间 = DateTime.Today;
            this.创建日期 = DateTime.Today;
        }

        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 查询所有提醒
        /// </summary>
        static readonly Func<Entities, ObjectQuery<提醒>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<提醒>>(
            (context) => (ObjectQuery<提醒>)context.提醒.
                OrderByDescending(m => m.提醒时间));
        /// <summary>
        /// 预编译查询0 -- 查询所有提醒，按提醒时间逆序排列
        /// </summary>
        public static ObjectQuery<提醒> GetTX(MyContext context)
        {
            return compiledQuery0.Invoke(context);
        }

        /// <summary>
        /// 预编译查询1 -- 查询最近7天提醒(包括已到期的)
        /// </summary>
        static readonly Func<Entities, ObjectQuery<提醒>> compiledQuery1 =
            CompiledQuery.Compile<Entities, ObjectQuery<提醒>>(
            (context) => (ObjectQuery<提醒>)context.提醒.
                Where(m => m.已完成 == false && (m.提醒时间 - DateTime.Now).Days <= 7).
                OrderByDescending(m => m.提醒时间));
        /// <summary>
        /// 预编译查询1 -- 查询最近7天提醒(包括已到期的)，按提醒时间逆序排列
        /// </summary>
        public static ObjectQuery<提醒> GetTX_In7Days(MyContext context)
        {
            return compiledQuery1.Invoke(context);
        }


        #endregion

    }
   
}
