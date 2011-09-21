using System;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{
    public partial class SourceRoomPaymentDetail : IValidatableObject
    {
        public SourceRoomPaymentDetail()
        {
            this.ID = Guid.NewGuid();
            this.缴费时间 = DateTime.Today;//缴费时间默认当前操作日期
        }


        //#region 预编译查询
        ///// <summary>
        ///// 预编译查询0 -- 查询所有
        ///// </summary>
        //static readonly Func<Entities, ObjectQuery<源房缴费明细>> compiledQuery0 =
        //    CompiledQuery.Compile<Entities, ObjectQuery<源房缴费明细>>(
        //    (context) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.
        //        OrderByDescending(m => m.缴费时间));

        ///// <summary>
        ///// 预编译查询1 -- 根据源房ID和缴费项2个条件过滤
        ///// </summary>
        //static readonly Func<Entities, Guid, string, ObjectQuery<源房缴费明细>> compiledQuery1 =
        //    CompiledQuery.Compile<Entities, Guid, string, ObjectQuery<源房缴费明细>>(
        //    (context, guid, payItem) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.
        //        Where(m => m.源房ID == guid && m.缴费项 == payItem).
        //        OrderByDescending(m => m.缴费时间));


        ///// <summary>
        ///// 预编译查询2 -- 根据源房ID过滤
        ///// </summary>
        //static readonly Func<Entities, Guid, ObjectQuery<源房缴费明细>> compiledQuery2 =
        //    CompiledQuery.Compile<Entities, Guid, ObjectQuery<源房缴费明细>>(
        //    (context, guid) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.
        //        Where(m => m.源房ID == guid).
        //        OrderByDescending(m => m.缴费时间));


        ///// <summary>
        ///// 预编译查询3 -- 根据缴费项过滤
        ///// </summary>
        //static readonly Func<Entities, string, ObjectQuery<源房缴费明细>> compiledQuery3 =
        //    CompiledQuery.Compile<Entities, string, ObjectQuery<源房缴费明细>>(
        //    (context, payItem) => (ObjectQuery<源房缴费明细>)context.源房缴费明细.
        //        Where(m => m.缴费项 == payItem).
        //        OrderByDescending(m => m.缴费时间));

        ///// <summary>
        /////  [调用预编译查询]查询源房缴费明细 - 默认按缴费时间逆序排列
        /////  1.查询所有源房缴费明细 - GetPayDetails(null,null)
        /////  2.根据源房ID和缴费项2个条件过滤 - GetPayDetails(源房ID, 缴费项)
        /////  3.根据源房ID过滤 - GetPayDetails(源房ID, null)
        /////  4.根据缴费项过滤 - GetPayDetails(null, 缴费项)
        ///// </summary>
        ///// <param name="源房ID"></param>
        ///// <param name="缴费项"></param>
        ///// <returns></returns>
        //public static ObjectQuery<源房缴费明细> GetPayDetails(Guid? 源房ID, string 缴费项)
        //{
        //    ObjectQuery<源房缴费明细> result = null;
        //    if (源房ID == null || 源房ID == Guid.Empty)
        //    {
        //        if(string.IsNullOrEmpty(缴费项))
        //        {
        //            result = compiledQuery0.Invoke(Main.context);
        //        }
        //        else
        //        {
        //            result = compiledQuery3.Invoke(Main.context, 缴费项);
        //        }
        //    }
        //    else
        //    { 
        //        if(string.IsNullOrEmpty(缴费项))
        //        {
        //            result = compiledQuery2.Invoke(Main.context, (Guid)源房ID);
        //        }
        //        else
        //        {
        //            result = compiledQuery1.Invoke(Main.context, (Guid)源房ID, 缴费项);
        //        }
        //    }
        //    return result;
        //}

        //#endregion


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            //源房缴费明细必须隶属于一个上级的源房
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                result.Add(new ValidationResult("请指定此缴费明细的源房! "));
                return result;
            }

            //校验所有非空属性
            //..................

            //时间校验
            //不可仅有单边值
            if (this.期始.HasValue && !this.期止.HasValue)
            {
                result.Add(new ValidationResult("缺少期止时间!"));
            }
            else if (!this.期始.HasValue && this.期止.HasValue)
            {
                result.Add(new ValidationResult("缺少期始时间!"));
            }
            //期止>期始，并且期始时间和上次此源房同类型缴费的期止时间应该连续
            if (this.期始.HasValue && this.期止.HasValue)
            {
                if (this.期止.Value.Date < this.期始.Value.Date)
                {
                    result.Add(new ValidationResult(string.Format("期止时间[{0}]不能小于期始时间[{1}]!",
                     this.期止.Value.ToShortDateString(), this.期始.Value.ToShortDateString())));
                }
                else
                {
                    //判断是否连续
                    DateTime temp = DateTime.MinValue;
                    List<SourceRoomPaymentDetail> list = this.SourceRoom.SourceRoomPaymentDetail.Where(m => m.缴费项 == this.缴费项 && m.期始.HasValue).OrderBy(n => n.期始).ToList();
                    int index = list.IndexOf(this);//得到this在此序列中的位置，然后判断前后的对象即可。
                    if (index > 0)//this不排首位
                    {
                        if (list[index - 1].期止.Value.Date.AddDays(1) != this.期始.Value.Date)
                            result.Add(new ValidationResult(string.Format("期始时间和上次此源房同类型缴费的期止时间应该连续，请检查[期止{0}]和[期始{1}]!",
                                                  list[index - 1].期止.Value.ToShortDateString(),
                                                  this.期始.Value.ToShortDateString())));
                    }
                    if (index < list.Count - 1)//this不排在末尾
                    {
                        if (this.期止.Value.Date.AddDays(1) != list[index + 1].期始.Value.Date)
                            result.Add(new ValidationResult(string.Format("期止时间和下次此源房同类型缴费的期始时间应该连续，请检查[期止{0}]和[期始{1}]!",
                                                  this.期止.Value.ToShortDateString(),
                                                  list[index + 1].期始.Value.ToShortDateString())));
                    }
                }
            }

            return result;
        }
    }
}
