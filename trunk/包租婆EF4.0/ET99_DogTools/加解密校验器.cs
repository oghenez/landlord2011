using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace ET99_DogTools
{
    public partial class 加解密校验器 : Form
    {
        public 加解密校验器()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 硬件加密狗计算HMAC_MD5
        /// </summary>
        /// <param name="MD5KeyIndexInDog">密钥index[范围1~8，对应加密狗中密钥存储范围1~8]</param>
        /// <param name="origin">原始字串</param>
        /// <returns>加密后字串</returns>
        public string HMAC_MD5_dog(int MD5KeyIndexInDog, string origin)
        {
            byte[] bytRandomCode = new byte[origin.Length];//第四个参数为随机数
            bytRandomCode = System.Text.Encoding.ASCII.GetBytes(origin);
            byte[] bytDigest = new byte[16];//第五个参数为硬件中计算结果

            //硬件中计算
            //第一个参数为设备的handle句柄
            //第二个参数为硬件中密钥索引
            //第三个参数为随机数长度
            //第四个参数为随机数
            //第五个参数为硬件中计算结果
            uint result = ET99_API.et_HMAC_MD5(ET99_API.dogHandle, MD5KeyIndexInDog, origin.Length, bytRandomCode, bytDigest);
            if (result == ET99_API.ET_SUCCESS)
                return System.Text.Encoding.Default.GetString(bytDigest);
            else//失败
                return "硬件中计算失败";
        }

        /// <summary>
        /// 读取指定地址数据区的字符串
        /// </summary>
        /// <param name="str">指定地址数据区的字符串</param>
        /// <param name="offset">偏移地址，范围0~999，字节为单位（整个数据区1000字节，每次读写限制长度60字节）</param>
        /// <param name="length">欲读取的字节长度</param>
        /// <param name="msg">成功与否详细信息</param>
        /// <returns>是否成功</returns>
        public bool ReadDataFromDog(out string str, int offset, int length, out string msg)
        {
            str = string.Empty;
            msg = "读取数据成功";
            byte[] zyn = new byte[length];
            //校验从偏移地址开始，欲写入的字节长度是否超过999
            if (offset + length > 1000)
            {
                msg = "从偏移地址开始，欲读取的字节长度超出数据区范围（整个数据区1000字节）！";
                return false;
            }
            uint resultmess;
            while (length > 60)
            {
                byte[] temp = new byte[60];
                resultmess = ET99_API.et_Read(ET99_API.dogHandle, (ushort)offset, 60, temp);//读取60字节 
                if (resultmess != ET99_API.ET_SUCCESS)
                {
                    msg = "其他错误";
                    if (resultmess == ET99_API.ET_HARD_ERROR)
                    {
                        msg = "硬件错误！";
                    }
                    if (resultmess == ET99_API.ET_ACCESS_DENY)
                    {
                        msg = "权限不够！";
                    }
                    return false;
                }
                Array.Copy(temp, 0, zyn, zyn.Length - length, 60);
                offset += 60;
                length -= 60;
            }
            //剩余数据，不需分割
            byte[] others = new byte[length];
            resultmess = ET99_API.et_Read(ET99_API.dogHandle, (ushort)offset, length, others);//读取 
            if (resultmess != ET99_API.ET_SUCCESS)
            {
                msg = "其他错误";
                if (resultmess == ET99_API.ET_HARD_ERROR)
                {
                    msg = "硬件错误！";
                }
                if (resultmess == ET99_API.ET_ACCESS_DENY)
                {
                    msg = "权限不够！";
                }
                return false;
            }
            Array.Copy(others, 0, zyn, zyn.Length - length, length);
            //转化成字符串
            str = System.Text.Encoding.Default.GetString(zyn);
            return true;

        }

        #region 密文形成及校验
        private void button1_Click(object sender, EventArgs e)
        {
            int index = 1;//默认仅打开第一个加密狗
            byte[] bytPID = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.PID);
            uint result = ET99_API.et_OpenToken(ref ET99_API.dogHandle, bytPID, index);
            //------------
            byte[] bytPIN = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.SOPIN);
            result = ET99_API.et_Verify(ET99_API.dogHandle, ET99_API.ET_VERIFY_SOPIN, bytPIN);
            if (result == ET99_API.ET_SUCCESS)
            {
                MessageBox.Show("加密狗认证成功，进入超级用户状态。");               
            }
            else
            {
                MessageBox.Show("加密狗认证失败，请检查！错误：{0}",
                                   ET99_API.ShowResultText(result));                
            }            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            //RC2加密
            string key16 = HMAC_MD5_dog(1, "武汉创方科技");
            textBox2.Text = 系统使用的加解密算法.RC2Encrypt(textBox1.Text, key16);
            button2.Text = "运用加密狗第一个密钥RC2加密后数据：(字节数" + System.Text.Encoding.Default.GetByteCount(textBox2.Text) + ")";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //RC2解密
            string key16 = HMAC_MD5_dog(1, "武汉创方科技");
            textBox3.Text = 系统使用的加解密算法.RC2Decrypt(textBox2.Text, key16);
            button3.Text = "运用加密狗第一个密钥解密后还原的数据：(字节数" + System.Text.Encoding.Default.GetByteCount(textBox3.Text) + ")";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //计算原始数据字节数
            string s = textBox1.Text;
            int intLong = System.Text.Encoding.Default.GetByteCount(s);
            button4.Text = "计算原始数据字节数：(字节数" + intLong + ")";

        }
#endregion


        #region 数据区解密测试
        private void button5_Click(object sender, EventArgs e)
        {
            string str;
            string msg;
            bool result = ReadDataFromDog(out str,int.Parse(textBox4.Text.Trim()),int.Parse(textBox5.Text.Trim()),out msg);
            textBox6.Text = result ? str.Replace('\0',' ') : msg;
        }
       

        private void button6_Click(object sender, EventArgs e)
        {
            //RC2解密
            string key16 = HMAC_MD5_dog(1, "武汉创方科技");
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                textBox7.Text = "没有数据";
                button6.Text = "运用加密狗第一个密钥解密后还原的数据：";
            }
            else
            {
                textBox7.Text = 系统使用的加解密算法.RC2Decrypt(textBox6.Text, key16);
                button6.Text = "运用加密狗第一个密钥解密后还原的数据：(字节数" + System.Text.Encoding.Default.GetByteCount(textBox7.Text) + ")";
            }
        }
        #endregion
    }
}
