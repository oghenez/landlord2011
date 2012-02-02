using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace ET99_DogTools
{
    public static class 系统使用的加解密算法
    {
        #region 系统使用的加解密算法(RC2算法 加密解密)
        /**===================================================================================================*
         *  ET99加密狗密钥存储区可以存储8个32字节密钥，用于HMAC-MD5计算。实际上相当于种子码算法，通过输入（每次不超过51字节）
         *  进行计算，产生结果，将结果与应用软件中的数据进行加密处理，产生密文存储在多功能锁中。这样在应用软件使用时，必须通过该
         *  把多功能锁中的密钥计算产生的结果与密文进行反向解密处理产生明文，供软件使用。
         *  
         *  因为RC2算法默认密钥大小128(Bit)=16字节=加密狗通过密钥存储区内的密钥加密运算后的结果长度
        ***===================================================================================================*/
        /// <summary>
        /// RC2 加密(用变长密钥对大量数据进行加密)
        /// </summary>
        /// <param name="EncryptString">待加密密文</param>
        /// <param name="EncryptKey">加密密钥-->即加密狗计算后的16字节数据结果</param>
        /// <returns>returns</returns>
        public static string RC2Encrypt(string EncryptString, string EncryptKey)
        {
            if (string.IsNullOrEmpty(EncryptString))
                throw (new Exception("密文不得为空"));
            if (string.IsNullOrEmpty(EncryptKey))
                throw (new Exception("密钥不得为空"));
            if (EncryptKey.Length < 5 || EncryptKey.Length > 16)//RC2算法有效密钥大小40~128(Bit)
                throw (new Exception("密钥必须为5-16位"));

            string m_strEncrypt = "";
            byte[] m_btIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            RC2CryptoServiceProvider m_RC2Provider = new RC2CryptoServiceProvider();
            try
            {
                byte[] m_btEncryptString = Encoding.Default.GetBytes(EncryptString);
                MemoryStream m_stream = new MemoryStream();
                CryptoStream m_cstream = new CryptoStream(m_stream,
                    m_RC2Provider.CreateEncryptor(Encoding.Default.GetBytes(EncryptKey), m_btIV),
                    CryptoStreamMode.Write);
                m_cstream.Write(m_btEncryptString, 0, m_btEncryptString.Length);
                m_cstream.FlushFinalBlock();
                m_strEncrypt = Convert.ToBase64String(m_stream.ToArray());
                m_stream.Close();
                m_stream.Dispose();
                m_cstream.Close();
                m_cstream.Dispose();
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_RC2Provider.Clear();
            }
            return m_strEncrypt;
        }
        /// <summary>
        /// RC2 解密(用变长密钥对大量数据进行加密)
        /// </summary>
        /// <param name="DecryptString">待解密密文</param>
        /// <param name="DecryptKey">解密密钥-->即加密狗计算后的16字节数据结果</param>
        /// <returns>returns</returns>
        public static string RC2Decrypt(string DecryptString, string DecryptKey)
        {
            if (string.IsNullOrEmpty(DecryptString))
                throw (new Exception("密文不得为空"));
            if (string.IsNullOrEmpty(DecryptKey))
                throw (new Exception("密钥不得为空"));
            if (DecryptKey.Length < 5 || DecryptKey.Length > 16)
                throw (new Exception("密钥必须为5-16位"));
            byte[] m_btIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            string m_strDecrypt = "";
            RC2CryptoServiceProvider m_RC2Provider = new RC2CryptoServiceProvider();
            try
            {
                byte[] m_btDecryptString = Convert.FromBase64String(DecryptString);
                MemoryStream m_stream = new MemoryStream();
                CryptoStream m_cstream = new CryptoStream(m_stream,
                    m_RC2Provider.CreateDecryptor(Encoding.Default.GetBytes(DecryptKey), m_btIV),
                    CryptoStreamMode.Write);
                m_cstream.Write(m_btDecryptString, 0, m_btDecryptString.Length);
                m_cstream.FlushFinalBlock();
                m_strDecrypt = Encoding.Default.GetString(m_stream.ToArray());
                m_stream.Close();
                m_stream.Dispose();
                m_cstream.Close();
                m_cstream.Dispose();
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m_RC2Provider.Clear();
            }
            return m_strDecrypt;
        }
        #endregion

    }
}
