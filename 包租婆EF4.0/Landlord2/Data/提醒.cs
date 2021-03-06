using System;
using System.Data.Objects;
using System.Linq;
using System.Text;

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

        //重载提醒的ToString方法。（方便加载进主窗体的ListBox控件）
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.提醒时间.ToShortDateString());
            sb.Append("\t");
            sb.Append(this.事项);
            
            return sb.ToString();
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
        /// 预编译查询1 -- 查询最近n天提醒(包括已到期的)
        /// </summary>
        static readonly Func<Entities,DateTime, ObjectQuery<提醒>> compiledQuery1 =
            CompiledQuery.Compile<Entities,DateTime, ObjectQuery<提醒>>(
            (context,endDate) => (ObjectQuery<提醒>)context.提醒.
                Where(m => m.已完成 == false && m.提醒时间 <= endDate).
                OrderBy(m => m.提醒时间));
        /// <summary>
        /// 预编译查询1 -- 查询最近n天提醒(包括已到期的)，按提醒时间顺序排列【紧急的排前面】
        /// </summary>
        public static ObjectQuery<提醒> GetTX_InSomeDays(MyContext context)
        {
            int alarmDays = int.Parse(context.system.FirstOrDefault(m => m.key == "alarmDays").value);
            return compiledQuery1.Invoke(context, DateTime.Today.AddDays(alarmDays));
        }


        #endregion

    }
   
}
