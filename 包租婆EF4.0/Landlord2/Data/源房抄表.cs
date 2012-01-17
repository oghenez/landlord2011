using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////

    public partial class 源房抄表
    {
        public 源房抄表()
        {
            this.ID = Guid.NewGuid();
            this.抄表时间 = DateTime.Now;//这里为详细时间，方便比较
        }

        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 查询所有
        /// </summary>
        static readonly Func<Entities, ObjectQuery<源房抄表>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<源房抄表>>(
            (context) => (ObjectQuery<源房抄表>)context.源房抄表.
                OrderByDescending(m => m.抄表时间));

        /// <summary>
        /// 预编译查询1 -- 根据源房ID过滤
        /// </summary>
        static readonly Func<Entities,Guid, ObjectQuery<源房抄表>> compiledQuery1 =
            CompiledQuery.Compile<Entities,Guid, ObjectQuery<源房抄表>>(
            (context,guid) => (ObjectQuery<源房抄表>)context.源房抄表.
                Where(m=>m.源房ID == guid).
                OrderByDescending(m => m.抄表时间));

        /// <summary>
        ///查询源房抄表记录，按抄表时间逆序 
        ///1.查询所有源房抄表记录 
        ///2.根据源房ID过滤 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ObjectQuery<源房抄表> GetYFCB(MyContext context,Guid? 源房ID)
        {
            ObjectQuery<源房抄表> result = null;
            if (源房ID == null || 源房ID == Guid.Empty)
            {
                result = compiledQuery0.Invoke(context);
            }
            else
            {
                result = compiledQuery1.Invoke(context, (Guid)源房ID);
            }
            return result;
        }

        /// <summary>
        /// 根据源房ID和抄表时间，得到该源房水电气最近一次的抄表值。
        /// </summary>
        /// <param name="源房ID"></param>
        /// <returns>返回double数组分别对应水、电、气</returns>
        public static double?[] GetNearestValue(MyContext context, Guid 源房ID,DateTime dt)
        {
            double?[] returnVal = new double?[3];
            ObjectQuery<源房抄表> result = compiledQuery1.Invoke(context, (Guid)源房ID);
            源房抄表 temp = result.FirstOrDefault(m => m.水止码.HasValue && m.抄表时间 < dt);
            returnVal[0] = temp == null ? null : temp.水止码;

            temp = result.FirstOrDefault(m => m.电止码.HasValue && m.抄表时间 < dt);
            returnVal[1] = temp == null ? null : temp.电止码;

            temp = result.FirstOrDefault(m => m.气表剩余字数.HasValue && m.抄表时间 < dt);
            returnVal[2] = temp == null ? null : temp.气表剩余字数;
            return returnVal;
        }

        #endregion
    }
}
