using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace 二房东信息提取器
{
    public class Root
    {
        public static BindingList<Customer> customerList;
        public static string AuthorName;//采集者

        public static void Serialize<T>(T obj)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StreamWriter wr = new StreamWriter("Customers.xml"))
            {
                xs.Serialize(wr, obj);
            }
        }

        public static T Deserialize<T>()
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StreamReader rd = new StreamReader("Customers.xml"))
            {
                return (T)xs.Deserialize(rd);
            }
        }
    }
}
