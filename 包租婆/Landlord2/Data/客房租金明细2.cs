using System;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{

    public partial class 客房租金明细 : IValidatableObject
    {
        public 客房租金明细()
        {
            this.ID = Guid.NewGuid();
            this.付款日期 = DateTime.Today;
        }

        //#region 预编译查询
        ///// <summary>
        ///// 预编译查询0 -- 查询所有
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<客房租金明细>> compiledQuery0 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<客房租金明细>>(
        //    (context) => (ObjectQuery<客房租金明细>)context.客房租金明细.
        //        OrderByDescending(m => m.起付日期));

        ///// <summary>
        ///// 预编译查询1 -- 根据客房ID过滤
        ///// </summary>
        //static readonly Func<Entities, Guid, ObjectQuery<客房租金明细>> compiledQuery1 =
        //    CompiledQuery.Compile<Entities, Guid, ObjectQuery<客房租金明细>>(
        //    (context, guid) => (ObjectQuery<客房租金明细>)context.客房租金明细.
        //        Where(m => m.客房ID == guid).
        //        OrderByDescending(m => m.起付日期));

        ///// <summary>
        /////  [调用预编译查询]查询客房租金明细 - 默认按起付日期逆序排列
        /////  1.查询所有客房租金明细 - GetRentDetails(null)
        /////  2.根据客房ID过滤 - GetRentDetails(客房ID, null)
        ///// </summary>
        ///// <param name="客房ID"></param>
        ///// <returns></returns>
        //public static ObjectQuery<客房租金明细> GetRentDetails(Guid? 客房ID)
        //{
        //    ObjectQuery<客房租金明细> result = null;
        //    if (客房ID == null || 客房ID == Guid.Empty)
        //    {
        //        result = compiledQuery0.Invoke(Main.context);
        //    }
        //    else
        //    {
        //        result = compiledQuery1.Invoke(Main.context, (Guid)客房ID);
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// 查询当前客房租户的所有租金明细,按起付日期逆序排列（包括之前续租的）
        ///// </summary>
        ///// <param name="客房"></param>
        ///// <returns></returns>
        //public static List<客房租金明细> GetRentDetails_Current(客房 kf)
        //{
        //    if(string.IsNullOrEmpty(kf.租户))
        //        return new List<客房租金明细>();
            
        //    //找到该客户最初的协议期始时间（最开始交租时间）
        //    var histories = kf.客房出租历史记录.
        //        Where(m => m.租户 == kf.租户 && m.身份证号 == kf.身份证号);
        //    DateTime begin = histories.Count() == 0 ? kf.期始.Value : histories.Min(n => n.期始); 

        //    return kf.客房租金明细.Where(m=>m.起付日期 >= begin.Date).
        //        OrderByDescending(m => m.起付日期).ToList();
        //}

        ///// <summary>
        ///// 查询当前客房租户的当前协议期内的所有租金明细,按起付日期逆序排列（不包括之前续租的）
        ///// </summary>
        ///// <param name="客房"></param>
        ///// <returns></returns>
        //public static List<客房租金明细> GetRentDetails_Current2(客房 kf)
        //{
        //    if (string.IsNullOrEmpty(kf.租户))
        //        return new List<客房租金明细>();

        //    //找到该客户当前协议期始时间（当前协议期最开始交租时间）
        //    DateTime begin = kf.期始.Value;

        //    return kf.客房租金明细.Where(m => m.起付日期 >= begin.Date).
        //        OrderByDescending(m => m.起付日期).ToList();
        //}
        //#endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            //客房租金明细必须隶属于一个上级的客房
            if (this.客房ID == null || this.客房ID == Guid.Empty)
            {
                result.Add(new ValidationResult("请指定此租金明细的客房! "));
                return result;
            }

            //校验所有非空属性
            //.............

            //时间校验            
            //期止>期始，并且期始时间和上次此源房同类型缴费的期止时间应该连续
            if (this.止付日期.Date < this.起付日期.Date)
            {
                result.Add(new ValidationResult(string.Format("止付日期[{0}]不能小于起付日期[{1}]!",
                 this.止付日期.ToShortDateString(), this.起付日期.ToShortDateString())));
            }
            else
            {
                //支付期是否在协议时间段内
                if (this.起付日期.Date < this.客房.期始.Value.Date)
                    result.Add(new ValidationResult(string.Format("起付日期[{0}]不能小于客房协议租期的期始日期[{1}]!",
                        this.起付日期.ToShortDateString(), this.客房.期始.Value.ToShortDateString())));

                if (this.止付日期.Date > this.客房.期止.Value.Date)
                    result.Add(new ValidationResult(string.Format("止付日期[{0}]不能大于客房协议租期的期止日期[{1}]!",
                        this.止付日期.ToShortDateString(), this.客房.期止.Value.ToShortDateString())));
            }

            return result;
        }
    }

   
}
