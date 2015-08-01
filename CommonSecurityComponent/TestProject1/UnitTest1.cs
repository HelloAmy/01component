// ***********************************************************************
// Assembly         : TestProject1
// Author           : zhujinrong
// Created          : 04-27-2015
//
// Last Modified By : zhujinrong
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="UnitTest1.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Lucky.CommonSecurity.Tool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    /// <summary>
    /// UnitTest1 的摘要说明
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// testContextInstance
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// UnitTest1
        /// </summary>
        public UnitTest1()
        {
        }

        /// <summary>
        /// 获取或设置测试上下文，该上下文提供
        /// 有关当前测试运行及其功能的信息。
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }

        #region 附加测试属性
        ////
        //// 编写测试时，还可使用以下附加属性:
        ////
        //// 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        //// [ClassInitialize()]
        //// public static void MyClassInitialize(TestContext testContext) { }
        ////
        //// 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        //// [ClassCleanup()]
        //// public static void MyClassCleanup() { }
        ////
        //// 在运行每个测试之前，使用 TestInitialize 来运行代码
        //// [TestInitialize()]
        //// public void MyTestInitialize() { }
        ////
        //// 在每个测试运行完之后，使用 TestCleanup 来运行代码
        //// [TestCleanup()]
        //// public void MyTestCleanup() { }
        ////
        #endregion

        /// <summary>
        /// 测试加密解密
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            string ori = "121212";
            string str = Security.EncryptDES(ori);

            string des = Security.DecryptDES(ori);
            Assert.AreEqual(ori, des);
        }
    }
}
