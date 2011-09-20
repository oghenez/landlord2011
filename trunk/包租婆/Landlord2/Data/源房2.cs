using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{
    public partial class 源房 : IValidatableObject
    {
        public static 源房 MyCreate()
        {
            return new 源房() { ID = Guid.NewGuid() };
        }

        //#region 预编译查询
        ///// <summary>
        ///// 预编译查询0 -- 查询所有
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<源房>> compiledQuery0 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<源房>>(
        //    (context) => (ObjectQuery<源房>)context.源房.
        //        OrderByDescending(m => m.源房涨租协定.Min(n => n.期始)));
        ///// <summary>
        ///// 预编译查询0 -- 查询所有源房，最近签约的排最前
        ///// </summary>
        //public static ObjectQuery<源房> GetYF()
        //{
        //    return compiledQuery0.Invoke(Main.context);
        //}

        ///// <summary>
        ///// 预编译查询1 -- 查询非历史源房
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<源房>> compiledQuery1 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<源房>>(
        //    (context) => (ObjectQuery<源房>)context.源房.
        //        Where(m => m.源房涨租协定.Max(n => n.期止) > DateTime.Now).
        //        OrderByDescending(m => m.源房涨租协定.Min(n => n.期始)));
        ///// <summary>
        ///// 预编译查询1 -- 查询非历史源房，最近签约的排最前
        ///// </summary>
        //public static ObjectQuery<源房> GetYF_NoHistory()
        //{
        //    return compiledQuery1.Invoke(Main.context);
        //}
        public static ObjectQuery<源房> GetYF_NoHistory(Entities context)
        {
            return compiledQuery1.Invoke(Main.context);
        }
        ///// <summary>
        ///// 预编译查询1 -- 查询历史源房
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<源房>> compiledQuery2 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<源房>>(
        //    (context) => (ObjectQuery<源房>)context.源房.
        //        Where(m => m.源房涨租协定.Max(n => n.期止) <= DateTime.Now).
        //        OrderByDescending(m => m.源房涨租协定.Min(n => n.期始)));
        ///// <summary>
        ///// 预编译查询0 -- 查询历史源房，最近签约的排最前
        ///// </summary>
        //public static ObjectQuery<源房> GetYF_History()
        //{
        //    return compiledQuery2.Invoke(Main.context);
        //}
        //#endregion

        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            //校验所有非空属性
            //...................

            //源房必须有‘源房涨租协定表’
            if (this.源房涨租协定.Count() == 0)
                result.Add(new ValidationResult("请填写协议租期!"));

            //校验源房下的‘源房涨租协定’表
            DateTime temp = DateTime.MinValue;
            foreach (var o in this.源房涨租协定.OrderBy(m => m.期始))
            {
                result.AddRange(o.Validate(validationContext));//时间校验
                //判断是否连续
                if (temp != DateTime.MinValue)
                {
                    if (temp.Date.AddDays(1) != o.期始.Date)
                    {
                        result.Add(new ValidationResult(string.Format("时间段不连续，请检查[期止{0}]和[期始{1}]!",
                            temp.ToShortDateString(), o.期始.ToShortDateString())));
                    }
                }
                temp = o.期止; //这里赋值
            }

            //调整‘源房涨租协定表’时，也许存在已租状态的客房，那么此时调整后的最后期始期止时间必须‘包含’所有客房租期的期始期止时间段
            if (this.源房涨租协定.Count > 0)
            {
                DateTime start = this.源房涨租协定.Min(m => m.期始);
                DateTime end = this.源房涨租协定.Max(m => m.期止);
                foreach (var o in this.客房.Where(m => !string.IsNullOrEmpty(m.租户)))
                {
                    if (o.期始 < start)
                        result.Add(new ValidationResult(string.Format("客房期始时间不能在源房期始时间之前！请检查源房起始租期[{0}]与客房[{1}]的期始时间{2}。",
                            start.ToShortDateString(), o.命名, o.期始.Value.ToShortDateString())));
                    if (o.期止 > end)
                        result.Add(new ValidationResult(string.Format("客房期止时间不能在源房期止时间之后！请检查源房期止时间[{0}]与客房[{1}]的期止时间{2}。",
                            end.ToShortDateString(), o.命名, o.期止.Value.ToShortDateString())));
                }
            }

            return result;
        }
    }
}
