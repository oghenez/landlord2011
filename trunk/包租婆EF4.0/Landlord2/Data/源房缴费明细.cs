using System;
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
            this.缴费时间 = DateTime.Now;//缴费时间默认当前操作时间，之后的查询会根据此降序排列，所以需要详细时间。
        }


        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 查询所有
        /// </summary>
        static readonly Func<Entities, ObjectQuery<源房缴费明细>> compiledQuery0 =
            CompiledQuery.Compile<Entities, ObjectQuery<源房缴费明细>>(
            (context) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.
                OrderByDescending(m => m.缴费时间));

        /// <summary>
        /// 预编译查询1 -- 根据源房ID和缴费项2个条件过滤
        /// </summary>
        static readonly Func<Entities, Guid, string, ObjectQuery<源房缴费明细>> compiledQuery1 =
            CompiledQuery.Compile<Entities, Guid, string, ObjectQuery<源房缴费明细>>(
            (context, guid, payItem) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.
                Where(m => m.源房ID == guid && m.缴费项 == payItem).
                OrderByDescending(m => m.缴费时间));


        /// <summary>
        /// 预编译查询2 -- 根据源房ID过滤
        /// </summary>
        static readonly Func<Entities, Guid, ObjectQuery<源房缴费明细>> compiledQuery2 =
            CompiledQuery.Compile<Entities, Guid, ObjectQuery<源房缴费明细>>(
            (context, guid) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.
                Where(m => m.源房ID == guid).
                OrderByDescending(m => m.缴费时间));


        /// <summary>
        /// 预编译查询3 -- 根据缴费项过滤
        /// </summary>
        static readonly Func<Entities, string, ObjectQuery<源房缴费明细>> compiledQuery3 =
            CompiledQuery.Compile<Entities, string, ObjectQuery<源房缴费明细>>(
            (context, payItem) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.
                Where(m => m.缴费项 == payItem).
                OrderByDescending(m => m.缴费时间));

        /// <summary>
        ///  [调用预编译查询]查询源房缴费明细 - 默认按缴费时间逆序排列
        ///  1.查询所有源房缴费明细
        ///  2.根据源房ID和缴费项2个条件过滤
        ///  3.根据源房ID过滤
        ///  4.根据缴费项过滤 
        /// </summary>
        /// <param name="源房ID"></param>
        /// <param name="缴费项"></param>
        /// <returns></returns>
        public static ObjectQuery<源房缴费明细> GetPayDetails(MyContext context, Guid? 源房ID, string 缴费项)
        {
            ObjectQuery<源房缴费明细> result = null;
            if (源房ID == null || 源房ID == Guid.Empty)
            {
                if(string.IsNullOrEmpty(缴费项))
                {
                    result = compiledQuery0.Invoke(context);
                }
                else
                {
                    result = compiledQuery3.Invoke(context, 缴费项);
                }
            }
            else
            { 
                if(string.IsNullOrEmpty(缴费项))
                {
                    result = compiledQuery2.Invoke(context, (Guid)源房ID);
                }
                else
                {
                    result = compiledQuery1.Invoke(context, (Guid)源房ID, 缴费项);
                }
            }
            return result;
        }

        /// <summary>
        /// 查询包含DateTime.Now时间点的已缴房租时间段
        /// 1、如果最近一次的缴费期始时间大于DateTime.Now时间点，则包含此时间段，并向下查询，找到包含DateTime.Now时间点的缴费时间区域，并叠加。）
        /// 2、如果欠费，即最近一次缴费期末时间小于DateTime.Now，那么返回最近缴费时间区域
        /// </summary>
        /// <param name="context"></param>
        /// <param name="yf"></param>
        /// <returns></returns>
        public static MyDate GetRecentPayMyDate(MyContext context, 源房 yf)
        {
            MyDate myDate = new MyDate();
            var result = compiledQuery1.Invoke(context, yf.ID, "房租").Execute(MergeOption.NoTracking).ToList();
            var temp = result.GetEnumerator();
            do
            {
                if (temp.MoveNext())
                {
                    myDate.Begin = MyDate.Smaller(temp.Current.期始.Value, myDate.Begin);
                    myDate.End = MyDate.Bigger(temp.Current.期止.Value, myDate.End);
                }
                else
                    break;
            }
            while (temp.Current.期始.Value.Date > DateTime.Now.Date);

            if (myDate.Begin == DateTime.MaxValue || myDate.End == DateTime.MinValue)
                return null;
            else
                return myDate;
        }
        #endregion

    }
}
