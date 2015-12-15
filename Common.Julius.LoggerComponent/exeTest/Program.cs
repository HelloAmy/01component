// ***********************************************************************
// Assembly         : EXETest
// Author           : zhujinrong
// Created          : 12-04-2015
//
// Last Modified By : zhujinrong
// Last Modified On : 12-07-2015
// ***********************************************************************
// <copyright file="Program.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Common.Julius.LoggerComponent;
using System.Net;

namespace EXETest
{
    /// <summary>
    /// Class Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The args.</param>
        internal static void Main(string[] args)
        {
            TestExcpetion();

            Console.WriteLine("end");
            Console.Read();
        }

        static void TestExcpetion()
        {
            try
            {
                TrackIDManager.GetInstance("zhujinrong");
                throw new Exception("自定义异常");
            }
            catch (Exception ex)
            {
                AppException app = new AppException(ex.Message, ex, ExceptionLevel.Error);
                LogManager.Log.WriteAppException(app);
            }
        }

        static void TestIp()
        {
            IPAddress ipAddr = Dns.Resolve(Dns.GetHostName()).AddressList[0];//获得当前IP地址
            string ip = ipAddr.ToString();
        }


        static void TestAppendData()
        {
            TrackIDManager.GetInstance("zhujinrong");

            MAppException model = new MAppException()
            {
                LogID = string.Empty,
                TimePoint = DateTime.Now,
                ApplicationName = "随便写",
                ErrorCode = "测试",
                ExceptionContext = "没有上下文",
                ExceptionLevel = ExceptionLevel.Info,
                ExceptionMsg = "没有什么错误",
                LocalIP = "localhost",
                OrginalExceptionMsg = "原始错误为null",
                TrackID = TrackIDManager.CurrentTrackID.TrackIdStr,
            };

            DALFactory.GetAppExceptionDAL(LogRecordType.FileLog).InsertAppException(model);
        }

        static void TestTrackIDManager()
        {
            TrackIDManager.GetInstance("zhujinrong");

            // 控制台程序报错
            Console.WriteLine("current TrackId：" + TrackIDManager.CurrentTrackID.TrackIdStr + TrackIDManager.CurrentTrackID.TrackIdStr.Length);

            TrackIDManager.GetInstance("zhujinrong");

            // 控制台程序报错
            Console.WriteLine("current TrackId：" + TrackIDManager.CurrentTrackID.TrackIdStr);
            Console.Read();
        }

        static void InsertAppException()
        {
            TrackIDManager.GetInstance("zhujinrong");
            MAppException model = new MAppException()
            {
                LogID = string.Empty,
                TimePoint = DateTime.Now,
                ApplicationName = "随便写",
                ErrorCode = "测试",
                ExceptionContext = "没有上下文",
                ExceptionLevel = ExceptionLevel.Info,
                ExceptionMsg = "没有什么错误",
                LocalIP = "localhost",
                OrginalExceptionMsg = "原始错误为null",
                TrackID = TrackIDManager.CurrentTrackID.TrackIdStr,
            };

            Console.WriteLine("end");
            Console.Read();
        }
    }
}
