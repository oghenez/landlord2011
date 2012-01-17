using System;
using System.Data.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////


    public partial class 客房租金明细
    {
        public 客房租金明细()
        {
            this.ID = Guid.NewGuid();
            this.付款日期 = DateTime.Today;
        }

        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 查询所有
        /// </summary>
        static readonly Func<Entities, ObjectQuery<客房租金明细>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<客房租金明细>>(
            (context) => (ObjectQuery<客房租金明细>)context.客房租金明细.
                OrderByDescending(m => m.起付日期));

        /// <summary>
        /// 预编译查询1 -- 根据客房ID过滤
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<客房租金明细>> compiledQuery1 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<客房租金明细>>(
            (context, guid) => (ObjectQuery<客房租金明细>)context.客房租金明细.
                Where(m => m.客房ID == guid).
                OrderByDescending(m => m.起付日期));

        /// <summary>
        ///  [调用预编译查询]查询客房租金明细 - 默认按起付日期逆序排列
        ///  1.查询所有客房租金明细 
        ///  2.根据客房ID过滤
        /// </summary>
        /// <param name="客房ID"></param>
        /// <returns></returns>
        public static ObjectQuery<客房租金明细> GetRentDetails(MyContext context, Guid? 客房ID)
        {
            ObjectQuery<客房租金明细> result = null;
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

        /// <summary>
        /// 查询当前客房租户的所有租金明细,按起付日期逆序排列（包括之前续租的）
        /// </summary>
        /// <param name="客房"></param>
        /// <returns></returns>
        public static List<客房租金明细> GetRentDetails_Current(客房 kf)
        {
            if(string.IsNullOrEmpty(kf.租户))
                return new List<客房租金明细>();
            
            //找到该客户最初的协议期始时间（最开始交租时间）
            var histories = kf.客房出租历史记录.
                Where(m => m.租户 == kf.租户 && m.身份证号 == kf.身份证号);
            DateTime begin = histories.Count() == 0 ? kf.期始.Value : histories.Min(n => n.期始); 

            return kf.客房租金明细.Where(m=>m.起付日期 >= begin.Date).
                OrderByDescending(m => m.起付日期).ToList();
        }

        /// <summary>
        /// 查询当前客房租户的当前协议期内的所有租金明细,按起付日期逆序排列（不包括之前续租的）
        /// </summary>
        /// <param name="客房"></param>
        /// <returns></returns>
        public static List<客房租金明细> GetRentDetails_Current2(客房 kf)
        {
            if (string.IsNullOrEmpty(kf.租户))
                return new List<客房租金明细>();

            //找到该客户当前协议期始时间（当前协议期最开始交租时间）
            DateTime begin = kf.期始.Value;

            return kf.客房租金明细.Where(m => m.起付日期 >= begin.Date).
                OrderByDescending(m => m.起付日期).ToList();
        }
        #endregion
    }

   
}
