using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Landlord2.Data
{
    /// <summary>
    /// 自定义时间类，包装2个DateTime(始末时间)，还有一个协议到期时间
    /// </summary>
    public class MyDate
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public DateTime? ContractEnd { get; set; }

        public MyDate()
        {
            //赋初始值，注意：此处故意begin > end
            Begin = DateTime.MaxValue;
            End = DateTime.MinValue;

            ContractEnd = null;
        }

        public static DateTime Bigger(DateTime dt1, DateTime dt2)
        {
            return (dt1 > dt2) ? dt1 : dt2;
        }

        public static DateTime Smaller(DateTime dt1, DateTime dt2)
        {
            return (dt1 < dt2) ? dt1 : dt2;
        }
    }
}
