using System;
using System.Data.Objects;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Landlord2.Data
{
    public partial class 客房 : IValidatableObject
    {
        public static 客房 MyCreate()
        {
            return new 客房() { ID = Guid.NewGuid(), 支付月数 = 3 };
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();


            //客房必须隶属于一个上级的源房
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                result.Add(new ValidationResult("请指定此客房上级的源房!"));
                return result;
            }

            //校验所有非空属性
            //。。。。。。。。。。。。。。

            //检测重名
            if (this.源房.客房.Count(m => m.命名 == this.命名) > 1)
                result.Add(new ValidationResult("客房命名重复，请重新指定!"));
            //支付月数 >= 1
            if (this.支付月数 < 1)
                result.Add(new ValidationResult("客房支付月数必须大于等于1个月!"));

            #region  时间校验
            //1、当存在‘租户’时，必须有期止、期始值，必须有电话1、联系地址、身份证号、
            if (!string.IsNullOrEmpty(this.租户))
            {
                if (!this.期始.HasValue || !this.期止.HasValue)
                    result.Add(new ValidationResult("存在租户时，必须有期始和期止时间!"));
                if (string.IsNullOrEmpty(this.电话1))
                    result.Add(new ValidationResult("存在租户时，[电话1]不可为空!"));
                if (string.IsNullOrEmpty(this.联系地址))
                    result.Add(new ValidationResult("存在租户时，[联系地址]不可为空!"));
                if (string.IsNullOrEmpty(this.身份证号))
                    result.Add(new ValidationResult("存在租户时，[身份证号]不可为空!"));
            }
            //2、不可仅有单边值
            if (this.期始.HasValue && !this.期止.HasValue)
            {
                result.Add(new ValidationResult("缺少期止时间!"));
            }
            else if (!this.期始.HasValue && this.期止.HasValue)
            {
                result.Add(new ValidationResult("缺少期始时间!"));
            }
            //3、期止>期始，并且时间范围必须在源房协议期之内
            if (this.期始.HasValue && this.期止.HasValue)
            {
                if (this.期止.Value.Date < this.期始.Value.Date)
                {
                    result.Add(new ValidationResult(string.Format("期止时间[{0}]不能小于期始时间[{1}]!",
                     this.期止.Value.ToShortDateString(), this.期始.Value.ToShortDateString())));
                }
                else
                {
                    DateTime min源房期始 = this.源房.源房涨租协定.Min(m => m.期始);
                    DateTime max源房期止 = this.源房.源房涨租协定.Max(m => m.期止);
                    if (this.期始.Value.Date < min源房期始)
                        result.Add(new ValidationResult(string.Format("期始时间[{0}]不能小于所隶属的源房的期始时间[{1}]!",
                            this.期始.Value.ToShortDateString(), min源房期始.ToShortDateString())));
                    if (this.期止 > max源房期止)
                        result.Add(new ValidationResult(string.Format("期止时间[{0}]不能大于所隶属的源房的期止时间[{1}]!",
                            this.期止.Value.ToShortDateString(), max源房期止.ToShortDateString())));
                }
            }
            #endregion          

            return result;
        }
    }


}
