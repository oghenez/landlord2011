using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Landlord2.Data
{
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
