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
        private Dog_Flag dogFlag;//新狗还是旧狗
        private string dogSN;//狗的SN
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
        private void output2(string msg)
        {
            DoThreadSafe(() => { listBox1.Items.Add(msg) ; });
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
        // 查询本机是否安装加密狗
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
                DoThreadSafe(() => { toolStripProgressBar1.Maximum = 16; });//新狗分为16个步骤
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
                    DoThreadSafe(() => { toolStripProgressBar1.Maximum = 14; });//旧狗分为14个步骤
                    return true;
                }
                msg = string.Format("系统未检测到加密狗，请检查！错误：{0}",
                    ET99_API.ShowResultText(result));
                return false;
            }
        }

        // 打开加密狗
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
                msg = "打开加密狗成功。";
                return true;
            }
            else
            {
                msg = string.Format("打开加密狗失败，请检查！错误：{0}",
                    ET99_API.ShowResultText(result));
                return false;
            }
        }

        // 校验加密狗，进入超级用户状态
        public bool VerifyDog(out string msg)
        {
            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            byte[] bytPIN = new byte[16];
            if (dogFlag == Dog_Flag.新狗)
                bytPIN = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.SOPIN_Default);
            else
                bytPIN = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.SOPIN);
            uint result = ET99_API.et_Verify(ET99_API.dogHandle, ET99_API.ET_VERIFY_SOPIN, bytPIN);
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

        //获取硬件SN
        public bool GetSN(out string msg)
        {
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
                dogSN = strSN;
                return true;
            }
            else
            {
                msg = "获取硬件SN失败！错误：" + ET99_API.ShowResultText(result);
                return false;
            }
        }

        //产生新的PID（针对新狗）
        public bool GenPID(out string msg)
        {
            string strSeed = Properties.Resources.PID种子;
            byte[] bytSeed;
            int iSeedLen = strSeed.Length;

            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            StringBuilder strNewPID = new StringBuilder();
            bytSeed = System.Text.Encoding.ASCII.GetBytes(strSeed);
            uint result = ET99_API.et_GenPID(ET99_API.dogHandle, iSeedLen, bytSeed, strNewPID);

            if (result == ET99_API.ET_SUCCESS)
            {
                msg = "成功写入新的PID到当前设备中！ -- " + strNewPID.ToString().Trim().Substring(0, 8);
                return true;
            }
            else
            {
                 msg ="写入新的PID到当前设备失败！ 错误：" + ET99_API.ShowResultText(result);
                 return false;
            }
        }

        //产生新的超级用户PIN（针对新狗）
        public bool GenSoPin(out string msg)
        {
            string strSeed = Properties.Resources.SOPIN种子;
            byte[] bytSeed;           
            int iSeedLen = strSeed.Length;

            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            StringBuilder strNewPIN = new StringBuilder();
            bytSeed = System.Text.Encoding.ASCII.GetBytes(strSeed);
            uint result = ET99_API.et_GenSOPIN(ET99_API.dogHandle, iSeedLen, bytSeed, strNewPIN);
            if (result == ET99_API.ET_SUCCESS)
            {
                msg = "成功产生新的超级用户PIN！请牢记 -- " + strNewPIN.ToString().Trim().Substring(0, 16);
                return true;
            }
            else
            {
                msg = "产生新的超级用户PIN失败！ 错误：" + ET99_API.ShowResultText(result);
                return false;
            }
        }

        //重置普通用户PIN为 ffffffffffffffff
        public bool ResetUserPin(out string msg)
        {
            string strSoPIN = Properties.Resources.SOPIN;
            byte[] bytPIN = new byte[16];

            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }     

            bytPIN = System.Text.Encoding.ASCII.GetBytes(strSoPIN);
            uint result = ET99_API.et_ResetPIN(ET99_API.dogHandle, bytPIN);
            if (result == ET99_API.ET_SUCCESS)
            {
                msg = "重置普通用户PIN为 FFFFFFFFFFFFFFFF 成功！";
                return true;
            }
            else
            {
                msg = "重置普通用户PIN失败！ 错误：" + ET99_API.ShowResultText(result);
                return false;
            }
        }

        //修改普通用户的PIN
        public bool ModifyUserPin(out string msg)
        {
            string strOldUserPin = Properties.Resources.UserPIN_Default;
            byte[] bytOldUserPin = new byte[16];
            string strNewUserPin = Properties.Resources.UserPIN;
            byte[] bytNewUserPin = new byte[16];

            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }              

            bytOldUserPin = System.Text.Encoding.ASCII.GetBytes(strOldUserPin);
            bytNewUserPin = System.Text.Encoding.ASCII.GetBytes(strNewUserPin);
            uint result = ET99_API.et_ChangeUserPIN(ET99_API.dogHandle, bytOldUserPin, bytNewUserPin);
            if (result == ET99_API.ET_SUCCESS)
            {
                msg = "普通用户PIN修改成功！进入普通用户状态。";
                return true;
            }
            else
            {
                msg = "普通用户PIN修改失败！ 错误：" + ET99_API.ShowResultText(result);
                return false;
            }
        }

        //设置前4个MD5校验密匙
        public bool SetMd5Key(out string msg)
        {
            msg = string.Empty;
            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            string[] strMd5Keys = new string[4];
            strMd5Keys[0] = Properties.Resources.HMAC_MD5_01;
            strMd5Keys[1] = Properties.Resources.HMAC_MD5_02;
            strMd5Keys[2] = Properties.Resources.HMAC_MD5_03;
            strMd5Keys[3] = Properties.Resources.HMAC_MD5_04;
            byte[] bytShortKey;
            for (int keyid = 1; keyid <= 4; keyid++)//循环写入前4个Md5Key
            {

                //生成需要写入的KEY
                bytShortKey = new byte[strMd5Keys[keyid - 1].Length];
                bytShortKey = System.Text.Encoding.ASCII.GetBytes(strMd5Keys[keyid - 1]);

                byte[] randombuffer = new byte[51];
                byte keylen = byte.Parse(strMd5Keys[keyid - 1].Length.ToString());
                byte randomlen = 51;

                byte[] sbMd5Key = new byte[32];
                byte[] sbdigest = new byte[16];

                //第一个参数是随机数，在设置密钥时没有作用
                //第二个参数是随机数长度，在设置密钥时没有作用
                //第三个参数是分配给客户的密钥
                //第四个参数是分配给客户的密钥的长度
                //第五个参数是返回的32字节的密钥，用于存到锁内
                //第六个参数在设置密钥时没有作用
                uint result = ET99_API.MD5_HMAC(randombuffer, randomlen, bytShortKey, keylen, sbMd5Key, sbdigest);
                result = ET99_API.et_SetKey(ET99_API.dogHandle, keyid, sbMd5Key);
                if (result == ET99_API.ET_SUCCESS)
                {
                    msg = "设置前4个MD5校验密匙成功！";
                }
                else
                {
                    msg = string.Format("设置第{0}个MD5校验密匙失败！错误：{1}", keyid, ET99_API.ShowResultText(result)) ;
                    return false;
                }
            }
            return true;
        }

        //使用设备进行MD5_HMAC验证计算
        public bool VerifyMd5HMAC(out string msg)
        {
            msg = string.Empty;
            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            string origin = "0123456789ABCD"; //测试用原始字符串
            for (int keyId = 1; keyId <= 4; keyId++)
            {
                string softResult = HMAC_MD5_soft(keyId, origin);
                string dogResult = HMAC_MD5_dog(keyId, origin);
                if (softResult == dogResult)
                {
                    msg = "MD5_HMAC验证计算通过！";
                }
                else
                {
                    msg = string.Format("验证第{0}个MD5_HMAC密钥失败！", keyId);
                    return false;
                }
            }
            return true;
        }

        //设置设备参数
        public bool SetConfig(out string msg)
        {
            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            byte bytUserReadOnly = ET99_API.ET_USER_READ_ONLY;//设置为只读模式
            byte bytSoPinRetries = byte.Parse(Properties.Resources.SOPIN重试次数);
            byte bytUserPinRetries = byte.Parse(Properties.Resources.UserPIN重试次数);
            byte bytBack = 0;


            uint result = ET99_API.et_SetupToken(ET99_API.dogHandle, bytSoPinRetries, bytUserPinRetries, bytUserReadOnly, bytBack);
            if (result == ET99_API.ET_SUCCESS)
            {
                msg ="设备参数设置成功！";
                return true;
            }
            else
            {
                msg ="设备参数设置失败！ 错误：" + ET99_API.ShowResultText(result);
                return false;
            }
        }

        //完全清空数据区
        public bool ClearData(out string msg)
        {
            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            //就是将锁内的数据区全部写成0x00
            byte[] zerodata = new byte[50]; //1000字节每次写50个字节，循环20次
            uint resultmess = 0;
            int i = 0;

            for (i = 0; i < 50; ++i)
            {
                zerodata[i] = 0x00;
            }

            for (i = 0; i < 20; ++i)
            {
                resultmess = ET99_API.et_Write(ET99_API.dogHandle, (ushort)(i * 50), 50, zerodata);
                if (resultmess != ET99_API.ET_SUCCESS)
                {
                    msg = "清空数据区失败！";
                    return false;
                }
            }
            msg = "成功清空数据区！" ;
            return true;
        }

        //写入数据区
        public bool WriteData(out string msg)
        {
            msg = string.Empty;
            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            //数据区根据不同版本进行设置
            //数据区约定：ET99数据区有1000字节，每次读写限制长度60字节。
            //我们把整个1000字节分为20份，每一份的偏移量为50字节。（相当于可存储20行文字信息，每行25个汉字容量）
            string[] origin = new string[8];
            origin[0] = Properties.Resources.Data00;
            origin[1] = Properties.Resources.Data01;
            origin[2] = Properties.Resources.Data02;
            origin[3] = Properties.Resources.Data03;
            foreach(Control rb in groupBox1.Controls)
            {
                if (rb is RadioButton && (rb as RadioButton).Checked)
                {
                    origin[4] = rb.Text;//【测试版】、【试用版】、【标准版】、【专业版】-->不同加密狗对应软件不同版本（软件直接读出显示在标题栏）
                    break;
                }
            }
            origin[5] = checkBox1.Checked ? maskedTextBox1.Text : "0";//源房套数限制，为0则不限制。（针对试用版或标准版）
            origin[6] = checkBox2.Checked ? maskedTextBox2.Text : "0";//试用版本到期天数，为0则不限制。（联合数据库中的首次启动日期判断到期）
            origin[7] = DateTime.Now.ToString("yyyyMMdd");

            for (int i = 0; i < 8; i++)
            {
                if (!WriteDataToDog(origin[i], i, out msg))
                {
                    return false;
                }
            }
            return true;
        }

        //读取整个数据区
        public bool ReadData(out string msg)
        {
            msg = string.Empty;
            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                string str;
                if (!ReadDataFromDog(out str, i, out msg))
                    return false;
                else
                {
                    sb.Append(i.ToString().PadLeft(2, '0') + ":");//加上标号，方便显示。
                    sb.Append(str);
                    sb.Append(Environment.NewLine);
                }
            }
            MessageBox.Show(sb.ToString(), "读取全部数据区 - 测试");
            return true;
        }

        //关闭LED
        public bool CloseLED(out string msg)
        {
            if (ET99_API.dogHandle == System.IntPtr.Zero)
            {
                msg = "请先打开设备！";
                return false;
            }

            uint result = ET99_API.et_TurnOffLED(ET99_API.dogHandle);
            if (result == ET99_API.ET_SUCCESS)
            {
                msg = "关闭LED成功！";
                return true;
            }
            else
            {
                msg = "关闭LED失败！ 错误：" + ET99_API.ShowResultText(result);
                return false;
            }
        }

        // 关闭加密狗
        public bool CloseDog(out string msg)
        {
            msg = string.Empty;
            uint result = ET99_API.et_CloseToken(ET99_API.dogHandle);
            if (result == ET99_API.ET_SUCCESS)
            {
                ET99_API.dogHandle = System.IntPtr.Zero;
                msg = "成功关闭加密狗";
                return true;
            }
            else
            {
                msg = string.Format("关闭加密狗失败，请检查！错误：{0}",
                    ET99_API.ShowResultText(result));
                return false;
            }
        }

        /// <summary>
        /// 软件计算HMAC_MD5
        /// 加密狗中可存储8个32字节HMAC_MD5密钥（每一个密钥都是由1个16字节密钥种子重复一次而成，这里存储的是8个16字节‘密钥种子’）
        /// </summary>
        /// <param name="MD5KeyIndexInDog">密钥index[范围1~8，对应加密狗中密钥存储范围1~8]</param>
        /// <param name="origin">原始字串</param>
        /// <returns>加密后字串</returns>
        public string HMAC_MD5_soft(int MD5KeyIndexInDog, string origin)
        {
            string[] strMd5Keys = new string[4];
            strMd5Keys[0] = Properties.Resources.HMAC_MD5_01;
            strMd5Keys[1] = Properties.Resources.HMAC_MD5_02;
            strMd5Keys[2] = Properties.Resources.HMAC_MD5_03;
            strMd5Keys[3] = Properties.Resources.HMAC_MD5_04;

            string strMD5Key = strMd5Keys[MD5KeyIndexInDog-1];
            byte[] bytRandomCode = new byte[origin.Length];//第一个参数是随机数
            bytRandomCode = System.Text.Encoding.ASCII.GetBytes(origin);
            byte randomlen = byte.Parse(origin.Length.ToString());//第二个参数是随机数长度
            byte[] bytShortKey = new byte[strMD5Key.Length];//第三个参数是分配给客户的密钥
            bytShortKey = System.Text.Encoding.ASCII.GetBytes(strMD5Key);
            byte keylen = byte.Parse(strMD5Key.Length.ToString());//第四个参数是分配给客户的密钥的长度
            byte[] sbMd5Key = new byte[32];//第五个参数没有作用
            byte[] sbdigest = new byte[16];//第六个参数为软件计算的结果

            //第一个参数是随机数
            //第二个参数是随机数长度
            //第三个参数是分配给客户的密钥
            //第四个参数是分配给客户的密钥的长度
            //第五个参数没有作用
            //第六个参数为软件计算的结果
            uint result = ET99_API.MD5_HMAC(bytRandomCode, randomlen, bytShortKey, keylen, sbMd5Key, sbdigest);
            if (result == ET99_API.ET_SUCCESS)
            {
                string strSoftDigest = string.Empty;
                for (int i = 0; i < 16; i++)
                    strSoftDigest += string.Format("{0:X2}", sbdigest[i]);
                return strSoftDigest;
            }
            else//失败
                return "软件计算失败";
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
            {
                string strSoftDigest = string.Empty;
                for (int i = 0; i < 16; i++)
                    strSoftDigest += string.Format("{0:X2}", bytDigest[i]);
                return strSoftDigest;
            }
            else//失败
                return "硬件中计算失败";
        }

        /// <summary>
        /// 将字符串写入指定地址的数据区
        /// </summary>
        /// <param name="origin">欲写入的字符串</param>
        /// <param name="index">范围【0~19】（我们把整个数据区1000字节分为20份，每一份的偏移量为50字节。）</param>
        /// <param name="msg">成功与否详细信息</param>
        /// <returns>是否成功</returns>
        public bool WriteDataToDog(string origin, int index, out string msg)
        {
            byte[] zyn = System.Text.Encoding.Default.GetBytes(origin);
            if (zyn.Length > 50)
            {
                msg = "信息超过50字节，请检查";
                return false;
            }
            ushort offset = (ushort)(index * 50);//偏移
            uint resultmess = ET99_API.et_Write(ET99_API.dogHandle, offset, zyn.Length, zyn);// 传入值
            if (resultmess == ET99_API.ET_SUCCESS)
            {
                msg = "写入成功！";
                return true;
            }
            else
            {
                msg = "其他错误";
                if (resultmess == ET99_API.ET_HARD_ERROR)
                {
                    msg = "硬件错误！";
                }
                if (resultmess == ET99_API.ET_ACCESS_DENY)
                {
                    msg ="权限不够！";
                }
                return false;
            }
        }

        /// <summary>
        /// 读取指定地址数据区的字符串
        /// </summary>
        /// <param name="str">指定地址数据区的字符串</param>
        /// <param name="index">范围【0~19】（我们把整个数据区1000字节分为20份，每一份的偏移量为50字节。）</param>
        /// <param name="msg">成功与否详细信息</param>
        /// <returns>是否成功</returns>
        public bool ReadDataFromDog(out string str, int index, out string msg)
        {
            str = string.Empty;
            byte[] zyn = new byte[50];
            ushort offset = (ushort)(index * 50);//偏移
            uint resultmess = ET99_API.et_Read(ET99_API.dogHandle, offset, 50, zyn);//读出50字节的数据
            if (resultmess == ET99_API.ET_SUCCESS)
            {
                msg = "读取数据成功！";
                str = System.Text.Encoding.Default.GetString(zyn).TrimEnd('\0');
                return true;
            }
            else
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
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            //生成加密狗
            button1.Enabled = false;
            toolStripProgressBar1.Value = 0;
            ThreadPool.QueueUserWorkItem(delegate
            {
                DoThreadSafe(() => { PrintLog("---开始生成加密狗---"); });
                CreateDog();
                DoThreadSafe(() => { button1.Enabled = true; });
                DoThreadSafe(() => { toolStripProgressBar1.Value = 0; });
                DoThreadSafe(() => { toolStripStatusLabel1.Text = string.Format("编号【{0}】的加密狗生成完毕！", dogSN) ; });
            });
        }

        /// <summary>
        /// 声明一个委托，针对流程执行的各个动作
        /// </summary>
        /// <param name="msg"></param>
        private delegate bool Step(out string msg) ;
        private void CallStep(Step step)
        {
            string msg;
            if (step(out msg))
            {
                output(msg);//ok
                DoThreadSafe(() => { toolStripProgressBar1.PerformStep(); });
            }
            else
            {
                output(msg);//error
                DoThreadSafe(() => { button1.Enabled = true; });
                Thread.CurrentThread.Abort();//终止调用线程，因为此处非主线程。
            }
        }

        /// <summary>
        /// 生成加密狗流程
        /// </summary>
        private void CreateDog()
        {
            //初始化dog
            ET99_API.dogHandle = System.IntPtr.Zero;
            dogSN = string.Empty;
            //查询加密狗
            CallStep(FindDog);
            //打开加密狗
            CallStep(OpenDog);
            //校验加密狗，进入超级用户状态
            CallStep(VerifyDog);
            //获取硬件SN
            CallStep(GetSN);
            if (dogFlag == Dog_Flag.新狗)
            {
                //产生新的PID（针对新狗）
                CallStep(GenPID);
                //产生新的超级用户PIN（针对新狗）
                CallStep(GenSoPin);
            }
            //重置普通用户PIN为 ffffffffffffffff
            CallStep(ResetUserPin);
            //修改普通用户的PIN【完毕后进入普通用户状态】
            CallStep(ModifyUserPin);
            //再次进入超级用户状态
            CallStep(VerifyDog);
            //设置前4个MD5校验密匙
            CallStep(SetMd5Key);
            //使用设备进行MD5_HMAC验证计算
            CallStep(VerifyMd5HMAC);
            //设置设备参数
            CallStep(SetConfig);
            //完全清空数据区
            CallStep(ClearData);
            //写入数据区
            CallStep(WriteData);
            //读取整个数据区
            CallStep(ReadData);
            //关闭LED
            CallStep(CloseLED); 
            //关闭设备
            CallStep(CloseDog);
       }

        private void button2_Click(object sender, EventArgs e)
        {
            //检测加密狗
            listBox1.Items.Clear();
            button2.Enabled = false;
            toolStripProgressBar1.Value = 0;
            ThreadPool.QueueUserWorkItem(delegate
            {
                DoThreadSafe(() => { listBox1.Items.Add("---开始检测加密狗---"); });
                CheckDog();
                DoThreadSafe(() => { button2.Enabled = true; });
                DoThreadSafe(() => { toolStripProgressBar1.Value = 0; });
                DoThreadSafe(() => { toolStripStatusLabel1.Text = string.Format("编号【{0}】的加密狗检测完毕！", dogSN); });
            });
        }
        private void CheckStep(Step step)
        {
            string msg;
            if (step(out msg))
            {
                output2(msg);//ok
                DoThreadSafe(() => { toolStripProgressBar1.PerformStep(); });
            }
            else
            {
                output2(msg);//error
                DoThreadSafe(() => { button2.Enabled = true; });
                Thread.CurrentThread.Abort();//终止调用线程，因为此处非主线程。
            }
        }
        private void CheckDog()
        {
            //初始化dog
            ET99_API.dogHandle = System.IntPtr.Zero;
            dogSN = string.Empty;
            //查询加密狗
            CheckStep(FindDog);
            //打开加密狗
            CheckStep(OpenDog);
            //校验加密狗，进入超级用户状态
            CheckStep(VerifyDog);
            //获取硬件SN
            CheckStep(GetSN);           
            
            //读取整个数据区
            CheckStep(ReadData);
            
            //关闭设备
            CheckStep(CloseDog);
        }
    }
}
