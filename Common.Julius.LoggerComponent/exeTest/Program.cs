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
            TrackIDManager.GetInstance("zhujinrong");

            // 控制台程序报错
            Console.WriteLine("current TrackId：" + TrackIDManager.CurrentTrackID.TrackIdStr);

            TrackIDManager.GetInstance("zhujinrong");

            // 控制台程序报错
            Console.WriteLine("current TrackId：" + TrackIDManager.CurrentTrackID.TrackIdStr);
            Console.Read();
        }
    }
}
