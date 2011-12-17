using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////


    public partial class 客房出租历史记录
    {
        public 客房出租历史记录()
        {
            this.ID = Guid.NewGuid();
        }

        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 查询所有
        /// </summary>
        static readonly Func<Entities, ObjectQuery<客房出租历史记录>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<客房出租历史记录>>(
            (context) => (ObjectQuery<客房出租历史记录>)context.客房出租历史记录.
                OrderByDescending(m => m.操作日期));

        /// <summary>
        /// 预编译查询1 -- 根据客房ID过滤
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<客房出租历史记录>> compiledQuery1 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<客房出租历史记录>>(
            (context, guid) => (ObjectQuery<客房出租历史记录>)context.客房出租历史记录.
                Where(m => m.客房ID == guid).
                OrderByDescending(m => m.操作日期));

        /// <summary>
        ///  [调用预编译查询]查询客房出租历史记录 - 默认按操作日期逆序排列
        ///  1.查询所有客房租金明细 - GetRentDetails(null)
        ///  2.根据客房ID过滤 - GetRentDetails(客房ID, null)
        /// </summary>
        /// <param name="客房ID"></param>
        /// <returns></returns>
        public static ObjectQuery<客房出租历史记录> GetKfHistoryDetails(MyContext context, Guid? 客房ID)
        {
            ObjectQuery<客房出租历史记录> result = null;
            if (客房ID == null || 客房ID == Guid.Empty)
            {
                result = compiledQuery0.Invoke(context);
            }
            else
            {
                result = compiledQuery1.Invoke(context, (Guid)客房ID);
            }
            return result;
        }


        #endregion

    }

   
}
