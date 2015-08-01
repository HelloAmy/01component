// ***********************************************************************
// Assembly         : Lucky.CommonSecurity.Tool
// Author           : zhujinrong
// Created          : 04-27-2015
//
// Last Modified By : zhujinrong
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="Security.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.IO;    
using System.Security.Cryptography;
using System.Text;

namespace Lucky.CommonSecurity.Tool
{
    /// <summary>
    /// 安全
    /// </summary>
    public class Security
    {
        /// <summary>
        /// 默认密钥向量
        /// </summary>
        private static byte[] keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// 默认解密key
        /// </summary>
        private static string key = "tian.xue";

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="encryptString">加密字符串</param>
        /// <returns>加密结果</returns>
        public static string EncryptDES(string encryptString)
        {
            return EncryptDES(encryptString, key);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="encryptString">要解密的字符串</param>
        /// <returns>解密结果</returns>
        public static string DecryptDES(string encryptString)
        {
            return DecryptDES(encryptString, key);
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dcsp = new DESCryptoServiceProvider();
                MemoryStream mstream = new MemoryStream();
                CryptoStream cstream = new CryptoStream(mstream, dcsp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cstream.Write(inputByteArray, 0, inputByteArray.Length);
                cstream.FlushFinalBlock();
                return Convert.ToBase64String(mstream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider dcsp = new DESCryptoServiceProvider();
                MemoryStream mstream = new MemoryStream();
                CryptoStream cstream = new CryptoStream(mstream, dcsp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cstream.Write(inputByteArray, 0, inputByteArray.Length);
                cstream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mstream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }
    }
}
