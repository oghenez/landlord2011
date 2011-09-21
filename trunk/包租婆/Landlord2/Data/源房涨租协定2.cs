using System;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{
    public partial class SourceRoomUpRentalAgreement : IValidatableObject
    {
        public SourceRoomUpRentalAgreement()
        {
            this.ID = Guid.NewGuid();
        }

        //#region 预编译查询
        ///// <summary>
        ///// 预编译查询0 -- 根据源房ID过滤
        ///// </summary>
        //static readonly Func<Entities, Guid, ObjectQuery<源房涨租协定>> compiledQuery0 =
        //    CompiledQuery.Compile<Entities, Guid, ObjectQuery<源房涨租协定>>(
        //    (context, guid) => (ObjectQuery<源房涨租协定>)context.源房涨租协定.
        //        Where(m => m.源房ID == guid).
        //        OrderBy(n=>n.期始));
        ///// <summary>
        ///// 预编译查询0 -- 根据源房ID过滤，按期始时间排序
        ///// </summary>
        //public static ObjectQuery<源房涨租协定> GetByYFid(Guid 源房ID)
        //{
        //    return compiledQuery0.Invoke(Main.context, 源房ID);
        //}
        //#endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            //源房涨租协定必须隶属于一个上级的源房
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                result.Add(new ValidationResult("请指定源房涨租协定上级的源房! "));
                return result;
            }

            //校验所有非空属性
            //....................

            //时间校验
            if (this.期止.Date < this.期始.Date)
                result.Add(new ValidationResult(string.Format("期止时间[{0}]不能小于期始时间[{1}]!",
                    this.期止.ToShortDateString(), this.期始.ToShortDateString())));           

            return result;
        }
    }
}
