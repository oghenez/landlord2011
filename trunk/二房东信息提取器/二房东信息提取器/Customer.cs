using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 二房东信息提取器
{
    [Serializable]
    public class Customer
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime ModifyTime { get; set; }

        //采集者
        public string Author { get; set; }

        public Customer()
        {
            ModifyTime = DateTime.Now;
        }
    }
}
