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
        /// 校验非空属性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string CheckNullOrEmpty(EntityObject entity, string columnName)
        {
            string result = string.Empty;
            Type type = entity.GetType();
            System.Reflection.PropertyInfo pInfo = type.GetProperty(columnName);
            //实体类为Property自动生成的EdmScalarPropertyAttribute属性
            EdmScalarPropertyAttribute att = (EdmScalarPropertyAttribute)Attribute.GetCustomAttribute(pInfo, typeof(EdmScalarPropertyAttribute));
            if (att != null) 
            {
                if (att.IsNullable == false)//针对非空列进行校验
                {
                    object value = type.GetProperty(columnName).GetValue(entity, null);//得到相应属性值
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                        result = string.Format("[{0}]不能为空值!",columnName);
                }
            }
            return result;
        }
    }

    public partial class 源房 : IDataErrorInfo
    {
        #region IDataErrorInfo Members

        private string _lastError = "";
        
        public string Error
        {
            get { return _lastError; }
        }
        private int i = 0;
        public string this[string columnName]
        {
            get
            {
                //for test...
                StringBuilder sb = new StringBuilder();
                //sb.Append("-------------------"+Environment.NewLine);
                for (int j = 1; j < 10; j++)
                {
                    System.Reflection.MethodInfo method = (System.Reflection.MethodInfo)(new System.Diagnostics.StackTrace().GetFrame(j).GetMethod());
                    if (method != null)
                    {
                        sb.Append(i + "--" + j + "--");
                        sb.Append(method.Name); 
                        sb.Append(Environment.NewLine); 
                    }
                }
                i++;
                sb.Append("###" + columnName+Environment.NewLine);
                sb.Append("-------------------"+Environment.NewLine);

                Console.Write(sb.ToString());
                _lastError = MyEntityHelper.CheckNullOrEmpty(this, columnName);
                ////额外校验
                //switch (columnName)
                //{
                //    case "LastName":
                //        if (String.IsNullOrEmpty(LastName))
                //            _lastError = "Please insert a name!";
                //        break;

                //    default: _lastError = "";
                //        break;
                //}
                return _lastError;
            }
        }

        #endregion
    }
    public partial class 源房涨租协定 : IDataErrorInfo
    {
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        partial void On月租金Changing(Decimal value)
        {
            //if (value < 1000)
            //    _errors.Add("月租金", "月租金小于1000 -- 实体验证测试");
        }

        public string Error
        {
            get { return string.Empty; }
        }

        public string this[string columnName]
        {
            get
            {
                if (_errors.ContainsKey(columnName))

                    return _errors[columnName];

                return string.Empty;
            }
        }
    }
}
