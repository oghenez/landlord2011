using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ET99_DogTools
{
    enum Dog_Flag
    {
        新狗, //出厂未经初始化
        旧狗  //曾经已初始化过
    }
    public partial class Form1 : Form
    {
        #region 线程安全的访问UI控件的方法

        public void DoThreadSafe(MethodInvoker function)
        {
            if (function == null) return;
            if (InvokeRequired) //UI以外的线程调用
                Invoke(function);
            else
                function();
        }

        #endregion
        private Dog_Flag dogFlag;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void output(string msg)
        {
            DoThreadSafe(() => { toolStripStatusLabel1.Text = msg; });
            DoThreadSafe(() => { PrintLog(msg); });
        }
        /// <summary>
        /// 写日志，当前目录下的log.txt文件。
        /// </summary>
        /// <param name="msg"></param>
        public static void PrintLog(string msg)
        {
            string path = Directory.GetCurrentDirectory();
            using (StreamWriter sw = File.AppendText(Path.Combine(path, "Dog.log")))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + msg);
            }
        }
        #region 加密狗相关
        /// <summary>
        /// 查询本机是否安装加密狗
        /// </summary>
        /// <param name="msg">回传检测信息</param>
        /// <returns></returns>
        public bool FindDog(out string msg)
        {
            msg = string.Empty;
            byte[] bytPID = new byte[8];
            int count = 0;
            bytPID = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.PID_Default);
            uint result = ET99_API.et_FindToken(bytPID, out count);
            if (result == ET99_API.ET_SUCCESS)
            {
                msg ="检测到加密狗--新狗";
                dogFlag = Dog_Flag.新狗;
                return true; 
            }
            else
            {
                bytPID = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.PID);
                result = ET99_API.et_FindToken(bytPID, out count);
                if (result == ET99_API.ET_SUCCESS)
                {
                    msg ="检测到加密狗--旧狗";
                    dogFlag = Dog_Flag.旧狗;
                    return true;
                }
                msg = string.Format("系统未检测到加密狗，请检查！错误：{0}",
                    ET99_API.ShowResultText(result));
                return false;
            }
        }


        /// <summary>
        /// 打开并进入加密狗
        /// </summary>
        /// <param name="errMsg"></param>
        public bool OpenDog(out string msg)
        {
            msg = string.Empty;
            int index = 1;//默认仅打开第一个加密狗
            byte[] bytPID = new byte[8];
            if (dogFlag == Dog_Flag.新狗)
                bytPID = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.PID_Default);
            else
                bytPID = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.PID);
            uint result = ET99_API.et_OpenToken(ref ET99_API.dogHandle, bytPID, index);
            if (result == ET99_API.ET_SUCCESS)//打开成功
            {
                byte[] bytPIN = new byte[16];
                if (dogFlag == Dog_Flag.新狗)
                    bytPIN = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.SOPIN_Default);
                else
                    bytPIN = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.SOPIN);
                result = ET99_API.et_Verify(ET99_API.dogHandle, ET99_API.ET_VERIFY_SOPIN, bytPIN);
                if (result == ET99_API.ET_SUCCESS)
                {
                    msg = "加密狗认证成功，进入超级用户状态。";
                    return true;
                }
                else
                {
                    msg = string.Format("加密狗认证失败，请检查！错误：{0}",
                                       ET99_API.ShowResultText(result));
                    return false;
                }
            }
            else
            {
                msg = string.Format("打开加密狗失败，请检查！错误：{0}",
                    ET99_API.ShowResultText(result));
                return false;
            }
        }

        //获取硬件SN
        public bool GetSN(out string msg)
        {
            msg = string.Empty;
            byte[] bytSN = new byte[8];

            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            uint result = ET99_API.et_GetSN(ET99_API.dogHandle, bytSN);
            if (result == ET99_API.ET_SUCCESS)
            {
                string strSN = "";
                for (int i = 0; i < 8; ++i)
                {
                    strSN += string.Format("{0:X2}", bytSN[i]);
                }

                msg = "获取硬件SN成功！-- " + strSN;
                return true;
            }
            else
            {
                msg = "获取硬件SN失败！错误：" + ET99_API.ShowResultText(result);
                return false;
            }
        }

        /// <summary>
        /// 关闭加密狗
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool CloseDog(out string errMsg)
        {
            errMsg = string.Empty;
            uint result = ET99_API.et_CloseToken(ET99_API.dogHandle);
            if (result == ET99_API.ET_SUCCESS)
            {
                ET99_API.dogHandle = System.IntPtr.Zero;
                return true;
            }
            else
            {
                errMsg = string.Format("关闭加密狗失败，请检查！错误：{0}",
                    ET99_API.ShowResultText(result));
                return false;
            }
        }

        /// <summary>
        /// 闪烁LED灯n次
        /// </summary>
        /// <param name="times">闪烁次数</param>
        /// <param name="interval">间隔毫秒数，300貌似不错</param>
        public static void FlashLED(int times, int interval)
        {
            int count = 0;
            System.Timers.Timer turnOffTimer = new System.Timers.Timer(interval);
            turnOffTimer.AutoReset = false;
            System.Timers.Timer turnOnTimer = new System.Timers.Timer(interval);
            turnOnTimer.AutoReset = false;
            turnOffTimer.Elapsed += new System.Timers.ElapsedEventHandler((m, n) =>
            {
                ET99_API.et_TurnOffLED(ET99_API.dogHandle);
                turnOnTimer.Start();
            });
            turnOnTimer.Elapsed += new System.Timers.ElapsedEventHandler((m, n) =>
            {
                count++;
                ET99_API.et_TurnOnLED(ET99_API.dogHandle);
                if (count < times)
                    turnOffTimer.Start();
            });

            turnOffTimer.Start();
        }

        /// <summary>
        /// 软件计算HMAC_MD5
        /// 加密狗中可存储8个32字节HMAC_MD5密钥（每一个密钥都是由1个16字节密钥种子重复一次而成，这里存储的是8个16字节‘密钥种子’）
        /// </summary>
        /// <param name="MD5KeyIndexInDog">密钥index[范围1~8，对应加密狗中密钥存储范围1~8]</param>
        /// <param name="origin">原始字串</param>
        /// <returns>加密后字串</returns>
        public static string HMAC_MD5_soft(int MD5KeyIndexInDog, string origin)
        {
            //uint result;
            //string strMD5Key = Properties.Resources.HMAC_MD5.Substring((MD5KeyIndexInDog - 1) * 16, 16);//获取对应index的‘密钥种子’
            //strMD5Key += strMD5Key;//重复一次，形成32字节密钥

            //byte[] bytRandomCode = new byte[origin.Length];//第一个参数是随机数
            //bytRandomCode = System.Text.Encoding.ASCII.GetBytes(origin);
            //byte randomlen = byte.Parse(origin.Length.ToString());//第二个参数是随机数长度
            //byte[] bytShortKey = new byte[strMD5Key.Length];//第三个参数是分配给客户的密钥
            //bytShortKey = System.Text.Encoding.ASCII.GetBytes(strMD5Key);
            //byte keylen = byte.Parse(strMD5Key.Length.ToString());//第四个参数是分配给客户的密钥的长度
            //byte[] sbMd5Key = new byte[32];//第五个参数没有作用
            //byte[] sbdigest = new byte[16];//第六个参数为软件计算的结果

            ////第一个参数是随机数
            ////第二个参数是随机数长度
            ////第三个参数是分配给客户的密钥
            ////第四个参数是分配给客户的密钥的长度
            ////第五个参数没有作用
            ////第六个参数为软件计算的结果
            //result = ET99_API.MD5_HMAC(bytRandomCode, randomlen, bytShortKey, keylen, sbMd5Key, sbdigest);
            //if (result == ET99_API.ET_SUCCESS)
            //{
            //    string strSoftDigest = string.Empty;
            //    for (int i = 0; i < 16; i++)
            //        strSoftDigest += string.Format("{0:X2}", sbdigest[i]);
            //    return strSoftDigest;
            //}
            //else//失败
            return string.Empty;
        }

        /// <summary>
        /// 硬件加密狗计算HMAC_MD5
        /// </summary>
        /// <param name="MD5KeyIndexInDog">密钥index[范围1~8，对应加密狗中密钥存储范围1~8]</param>
        /// <param name="origin">原始字串</param>
        /// <returns>加密后字串</returns>
        public static string HMAC_MD5_dog(int MD5KeyIndexInDog, string origin)
        {
            uint result;

            byte[] bytRandomCode = new byte[origin.Length];//第四个参数为随机数
            bytRandomCode = System.Text.Encoding.ASCII.GetBytes(origin);
            byte[] bytDigest = new byte[16];//第五个参数为硬件中计算结果

            //硬件中计算
            //第一个参数为设备的handle句柄
            //第二个参数为硬件中密钥索引
            //第三个参数为随机数长度
            //第四个参数为随机数
            //第五个参数为硬件中计算结果
            result = ET99_API.et_HMAC_MD5(ET99_API.dogHandle, MD5KeyIndexInDog, origin.Length, bytRandomCode, bytDigest);
            if (result == ET99_API.ET_SUCCESS)
            {
                string strSoftDigest = string.Empty;
                for (int i = 0; i < 16; i++)
                    strSoftDigest += string.Format("{0:X2}", bytDigest[i]);
                return strSoftDigest;
            }
            else//失败
                return string.Empty;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            toolStripProgressBar1.Value = 0;
            ThreadPool.QueueUserWorkItem(delegate
            {
                CreateDog();
                DoThreadSafe(() => { button1.Enabled = true; });
            });
        }

        /// <summary>
        /// 生成加密狗流程
        /// </summary>
        private void CreateDog()
        {
            string msg;
            //初始化dog
            ET99_API.dogHandle = System.IntPtr.Zero;
            //查询加密狗 
            if (FindDog(out msg))
            {
                output(msg);//ok
                DoThreadSafe(() => { toolStripProgressBar1.PerformStep(); });
            }
            else
            {
                output(msg);//error
                return;
            }
            //打开并进入加密狗
            if (OpenDog(out msg))
            {
                output(msg);//ok
                DoThreadSafe(() => { toolStripProgressBar1.PerformStep(); });
            }
            else
            {
                output(msg);//error
                return;
            }
            //获取硬件SN
            if (GetSN(out msg))
            {
                output(msg);//ok
                DoThreadSafe(() => { toolStripProgressBar1.PerformStep(); });
            }
            else
            {
                output(msg);//error
                return;
            }
            //修改普通用户的PIN
            //产生新的PID
            //产生新的超级用户PIN
            //重置普通用户PIN为 ffffffffffffffff
            //设置MD5校验密匙
            //设置设备参数
            //使用设备进行MD5_HMAC验证计算
            //完全清空数据区
            //关闭设备
            //LED闪烁3次
        }
    }
}
