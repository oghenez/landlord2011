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

        /// <summary>
        /// 校验所有非空属性; 如果是int16,int32,float,double,decimal类型，同时进行‘非负’判断。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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
    public partial class 客房租金明细 : ICheck
    {
        public string CheckRules()
        {
            string returnStr = string.Empty;

            //客房租金明细必须隶属于一个上级的客房
            if (this.客房ID == null || this.客房ID == Guid.Empty)
            {
                returnStr += "请指定此租金明细的客房! " + Environment.NewLine;
                return returnStr;
            }

            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            //时间校验            
            //期止>期始，并且期始时间和上次此源房同类型缴费的期止时间应该连续
            if (this.止付日期.Date < this.起付日期.Date)
            {
                returnStr += string.Format("止付日期[{0}]不能小于起付日期[{1}]!",
                 this.止付日期.ToShortDateString(), this.起付日期.ToShortDateString()) + Environment.NewLine;
            }
            else
            {
                //支付期是否在协议时间段内
                if (this.起付日期.Date < this.客房.期始.Value.Date)
                    returnStr += string.Format("起付日期[{0}]不能小于客房协议租期的期始日期[{1}]!",
                        this.起付日期.ToShortDateString(), this.客房.期始.Value.ToShortDateString()) + Environment.NewLine;

                if(this.止付日期.Date > this.客房.期止.Value.Date)
                    returnStr += string.Format("止付日期[{0}]不能大于客房协议租期的期止日期[{1}]!",
                        this.止付日期.ToShortDateString(), this.客房.期止.Value.ToShortDateString()) + Environment.NewLine;
            }
            return returnStr;
        }
    }
    public partial class 源房缴费明细 : ICheck
    {

        public string CheckRules()
        {
            string returnStr = string.Empty;

            //源房缴费明细必须隶属于一个上级的源房
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                returnStr += "请指定此缴费明细的源房! " + Environment.NewLine;
                return returnStr;
            }

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
                    DateTime temp = DateTime.MinValue;
                    List<源房缴费明细> list = this.源房.源房缴费明细.Where(m => m.缴费项 == this.缴费项 && m.期始.HasValue).OrderBy(n => n.期始).ToList();
                    int index = list.IndexOf(this);//得到this在此序列中的位置，然后判断前后的对象即可。
                    if (index > 0)//this不排首位
                    {
                        if (list[index - 1].期止.Value.Date.AddDays(1) != this.期始.Value.Date)
                            returnStr += string.Format("期始时间和上次此源房同类型缴费的期止时间应该连续，请检查[上次期止{0}]和[本次期始{1}]!",
                                                  list[index - 1].期止.Value.ToShortDateString(), 
                                                  this.期始.Value.ToShortDateString()) + Environment.NewLine;
                    }
                    if (index < list.Count-1)//this不排在末尾
                    {
                        if(this.期止.Value.Date.AddDays(1) != list[index+1].期始.Value.Date)
                            returnStr += string.Format("期止时间和下次此源房同类型缴费的期始时间应该连续，请检查[本次期止{0}]和[下次期始{1}]!",
                                                  this.期止.Value.ToShortDateString(),
                                                  list[index + 1].期始.Value.ToShortDateString()) + Environment.NewLine;
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
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                returnStr += "请指定此客房上级的源房!" + Environment.NewLine;
                return returnStr;
            }

            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            //检测重名
            if (this.源房.客房.Count(m => m.命名 == this.命名) > 1)
                returnStr += "客房命名重复，请重新指定!" + Environment.NewLine;

            //支付月数 >= 1
            if(this.支付月数 < 1)
                returnStr += "客房支付月数必须大于等于1个月!" + Environment.NewLine;

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
                    DateTime min源房期始 = this.源房.源房涨租协定.Min(m => m.期始).Date;
                    DateTime max源房期止 = this.源房.源房涨租协定.Max(m => m.期止).Date;
                    if (this.期始.Value.Date < min源房期始)
                        returnStr += string.Format("期始时间[{0}]不能小于所隶属的源房的期始时间[{1}]!",
                            this.期始.Value.ToShortDateString(),min源房期始.ToShortDateString()) +Environment.NewLine;
                    if (this.期止.Value.Date > max源房期止)
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

            //调整‘源房涨租协定表’时，也许存在已租状态的客房，那么此时调整后的最后期始期止时间必须‘包含’所有客房租期的期始期止时间段
            if (this.源房涨租协定.Count > 0)
            {
                DateTime start = this.源房涨租协定.Min(m => m.期始);
                DateTime end = this.源房涨租协定.Max(m => m.期止);
                foreach (var o in this.客房.Where(m => !string.IsNullOrEmpty(m.租户)))
                {
                    if (o.期始 < start)
                        returnStr += string.Format("客房期始时间不能在源房期始时间之前！请检查源房起始租期[{0}]与客房[{1}]的期始时间{2}。",
                            start.ToShortDateString(), o.命名, o.期始.Value.ToShortDateString()) + Environment.NewLine;
                    if (o.期止 > end)
                        returnStr += string.Format("客房期止时间不能在源房期止时间之后！请检查源房期止时间[{0}]与客房[{1}]的期止时间{2}。",
                            end.ToShortDateString(), o.命名, o.期止.Value.ToShortDateString()) + Environment.NewLine;
                } 
            }

            return returnStr;
        }

    }
    public partial class 源房涨租协定 :ICheck
    {
        public string CheckRules()
        {
            string returnStr = string.Empty;

            //源房涨租协定必须隶属于一个上级的源房
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                returnStr += "请指定源房涨租协定上级的源房! " + Environment.NewLine;
                return returnStr;
            }

            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            //时间校验
            if (this.期止.Date < this.期始.Date)
                returnStr += string.Format("期止时间[{0}]不能小于期始时间[{1}]!",
                    this.期止.ToShortDateString(),this.期始.ToShortDateString()) + Environment.NewLine;
            return returnStr;
        }
    }

    public partial class 装修明细 : ICheck
    {
        public string CheckRules()
        {
            string returnStr = string.Empty;
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                returnStr += "请指定装修明细所属的源房！ " + Environment.NewLine;
                return returnStr;
            }

            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            return returnStr;
        }
    }

    public partial class 源房抄表 : ICheck
    {
        public string CheckRules()
        {
            string returnStr = string.Empty;
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                returnStr += "请指定抄表记录所属的源房！ " + Environment.NewLine;
                return returnStr;
            }

            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            //水电气的止码必须要至少有一个
            if (this.水止码 == null && this.电止码 == null && this.气表剩余字数 == null)
                returnStr += "水电气止码不可全部为空！" + Environment.NewLine;
            return returnStr;
        }
    }

    public partial class 提醒 : ICheck
    {
        public string CheckRules()
        {
            string returnStr = string.Empty;
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                returnStr += "请指定提醒所涉及的源房！" + Environment.NewLine;
                return returnStr;
            }
            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            return returnStr;
        }
    }

    public partial class 日常损耗 : ICheck
    {
        public string CheckRules()
        {
            string returnStr = string.Empty;
            if (this.源房ID == null || this.源房ID == Guid.Empty)
            {
                returnStr += "请指定日常损耗所涉及的源房！" + Environment.NewLine;
                return returnStr;
            }
            //校验所有非空属性
            returnStr += MyEntityHelper.CheckNullOrEmptyAndABS(this);

            return returnStr;
        }
    }
}
