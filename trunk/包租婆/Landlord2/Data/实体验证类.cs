using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Objects.DataClasses;

namespace Landlord2.Data.kkk
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





}
