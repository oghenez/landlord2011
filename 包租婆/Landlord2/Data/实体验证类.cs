using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Objects.DataClasses;

namespace Landlord2.Data
{
    /// <summary>
    /// 实体Helper类
    /// </summary>
    public class MyEntityHelper
    {
        /// <summary>
        /// 校验所有非空属性
        /// 当flag = true时，如果是int16,int32,float,double,decimal类型，同时进行‘非负’判断。
        /// </summary>
        /// <param name="entity">实体实例</param>
        /// <param name="flag">是否需要校验‘非负’</param>
        /// <returns>如果验证通过，回传string.Empty，否则回传具体错误信息。</returns>
        public static string CheckNullOrEmptyAndABS(EntityObject entity, bool flag)
        {
            StringBuilder sb = new StringBuilder();
            Type type = entity.GetType();
            foreach (System.Reflection.PropertyInfo pInfo in type.GetProperties())
            {
                //实体类为Property自动生成的EdmScalarPropertyAttribute属性
                var att = Attribute.GetCustomAttribute(pInfo, typeof(EdmScalarPropertyAttribute));
                if (att != null)
                {
                    if (((EdmScalarPropertyAttribute)att).IsNullable == false)//针对非空列进行校验
                    {
                        object value = pInfo.GetValue(entity, null);//得到相应属性值
                        if(value == null || string.IsNullOrEmpty(value.ToString()))
                        {
                            sb.Append(string.Format("[{0}]--不能为空值!",pInfo.Name));
                            sb.Append(Environment.NewLine);
                        }
                        if (flag)
                        {
                            if (value is Int16 || value is Int32 || value is float || value is double || value is decimal)
                            {
                                if (value.ToString()[0] == '-')
                                {
                                    sb.Append(string.Format("[{0}]--不能为负数!", pInfo.Name));
                                    sb.Append(Environment.NewLine);
                                }
                            } 
                        }
                    }
                }
            }
            return sb.ToString();
        }

        // 校验所有非空属性，如果是int16,int32,float,double,decimal类型，同时进行‘非负’判断。
        public static string CheckNullOrEmptyAndABS(EntityObject entity)
        {
           return CheckNullOrEmptyAndABS(entity, true);
        }
    }

    #region 自定义ICheck接口，每个实体继承，进行规则验证。
    /// <summary>
    /// 自定义ICheck接口，每个实体继承，进行规则验证。
    /// </summary>
    interface ICheck
    {
        /// <summary>
        /// 如果验证通过，回传string.Empty，否则回传具体错误信息。
        /// </summary>
        /// <returns></returns>
        string CheckRules();
    } 
    #endregion
    public partial class 源房缴费明细 : ICheck
    {

        public string CheckRules()
        {
            string returnStr = string.Empty;

            //源房缴费明细必须隶属于一个上级的源房
            if (this.源房 == null)
                returnStr += "请指定此缴费明细的源房! " + Environment.NewLine;

            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            //时间校验
            //不可仅有单边值
            if (this.期始.HasValue && !this.期止.HasValue)
            {
                returnStr += "缺少期止时间!" + Environment.NewLine;
            }
            else if (!this.期始.HasValue && this.期止.HasValue)
            {
                returnStr += "缺少期始时间!" + Environment.NewLine;
            }
            //期止>期始，并且期始时间和上次此源房同类型缴费的期止时间应该连续
            if (this.期始.HasValue && this.期止.HasValue)
            {
                if (this.期止.Value.Date < this.期始.Value.Date)
                {
                    returnStr += string.Format("期止时间[{0}]不能小于期始时间[{1}]!",
                     this.期止.Value.ToShortDateString(), this.期始.Value.ToShortDateString()) + Environment.NewLine;
                }
                else
                {
                    //判断是否连续
                    var entities = this.源房.源房缴费明细.Where(m => m.缴费项 == this.缴费项).ToList();
                    entities.Remove(this);//this肯定包含在其中
                    DateTime? max = entities.Max(n => n.期止);
                    if (max.HasValue && max.Value.Date.AddDays(1) != this.期始.Value.Date)
                    {
                        returnStr += string.Format("期始时间和上次此源房同类型缴费的期止时间应该连续，请检查[期止{0}]和[期始{1}]!",
                                                   max.Value.ToShortDateString(), this.期始.Value.ToShortDateString()) + Environment.NewLine;
                    }
                }
            }     
            return returnStr;
        }
    }
    public partial class 客房 : ICheck
    {
        public string CheckRules()
        {
            string returnStr = string.Empty;
            
            //客房必须隶属于一个上级的源房
            if (this.源房 == null)
                returnStr += "请指定此客房上级的源房! " + Environment.NewLine;

            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            #region  时间校验
            //1、当存在‘租户’时，必须有期止、期始值，必须有电话1、联系地址、身份证号、
            if (!string.IsNullOrEmpty(this.租户))
            {
                if (!this.期始.HasValue || !this.期止.HasValue)
                    returnStr += string.Format("存在租户时，必须有期始和期止时间!") + Environment.NewLine;
                if(string.IsNullOrEmpty(this.电话1))
                    returnStr += string.Format("存在租户时，[电话1]不可为空!") + Environment.NewLine;
                if(string.IsNullOrEmpty(this.联系地址))
                    returnStr += string.Format("存在租户时，[联系地址]不可为空!") + Environment.NewLine;
                if(string.IsNullOrEmpty(this.身份证号))
                    returnStr += string.Format("存在租户时，[身份证号]不可为空!") + Environment.NewLine;
            }
            //2、不可仅有单边值
            if (this.期始.HasValue && !this.期止.HasValue)
            {
                returnStr += "缺少期止时间!" + Environment.NewLine;
            }
            else if (!this.期始.HasValue && this.期止.HasValue)
            {
                returnStr += "缺少期始时间!" + Environment.NewLine;
            }
            //3、期止>期始，并且时间范围必须在源房协议期之内
            if (this.期始.HasValue && this.期止.HasValue)
            {
                if (this.期止.Value.Date < this.期始.Value.Date)
                {
                    returnStr += string.Format("期止时间[{0}]不能小于期始时间[{1}]!",
                     this.期止.Value.ToShortDateString(), this.期始.Value.ToShortDateString()) + Environment.NewLine;
                }
                else
                {
                    DateTime min源房期始 = this.源房.源房涨租协定.Min(m => m.期始);
                    DateTime max源房期止 = this.源房.源房涨租协定.Max(m => m.期止);
                    if (this.期始.Value.Date < min源房期始)
                        returnStr += string.Format("期始时间[{0}]不能小于所隶属的源房的期始时间[{1}]!",
                            this.期始.Value.ToShortDateString(),min源房期始.ToShortDateString()) +Environment.NewLine;
                    if (this.期止 > max源房期止)
                        returnStr += string.Format("期止时间[{0}]不能大于所隶属的源房的期止时间[{1}]!",
                            this.期止.Value.ToShortDateString(), max源房期止.ToShortDateString()) + Environment.NewLine;
                }
            }            
            #endregion
          
            return returnStr;
        }
    }
    public partial class 源房:ICheck
    {
        public string CheckRules()
        {
            string returnStr = string.Empty;
            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            //源房必须有‘源房涨租协定表’
            if (this.源房涨租协定.Count() == 0)
                returnStr += "请填写协议租期!" + Environment.NewLine;

            //校验源房下的‘源房涨租协定’表
            DateTime temp = DateTime.MinValue;
            foreach (var o in this.源房涨租协定.OrderBy(m=>m.期始))
            {
                returnStr += o.CheckRules();//时间校验
                //判断是否连续
                if (temp != DateTime.MinValue)
                {
                    if (temp.Date.AddDays(1) != o.期始.Date)
                    {
                        returnStr += string.Format("时间段不连续，请检查[期止{0}]和[期始{1}]!",
                            temp.ToShortDateString(), o.期始.ToShortDateString()) + Environment.NewLine ;
                    }
                }
                temp = o.期止; //这里赋值
            }

            return returnStr;
        }
    }
    public partial class 源房涨租协定 :ICheck
    {
        public string CheckRules()
        {
            string returnStr = string.Empty;
            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            //时间校验
            if (this.期止.Date < this.期始.Date)
                returnStr += string.Format("期止时间[{0}]不能小于期始时间[{1}]!",
                    this.期止.ToShortDateString(),this.期始.ToShortDateString()) + Environment.NewLine;
            return returnStr;
        }
    }
}
