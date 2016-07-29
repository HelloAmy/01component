// ***********************************************************************
// Assembly         : Help.Common.Factory
// Author           : zhujinrong
// Created          : 05-20-2016
//
// Last Modified By : zhujinrong
// Last Modified On : 07-22-2016
// ***********************************************************************
// <copyright file="RouteFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Help.Common.Factory
{
    /// <summary>
    /// 路由工厂
    /// </summary>
    public class RouteFactory
    {
        /// <summary>
        /// API地址
        /// </summary>
        public static string APIAddress
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["APIAddress"];
            }
        }
    }
}
