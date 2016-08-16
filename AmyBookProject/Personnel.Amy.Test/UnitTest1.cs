using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Personnel.Amy.Business;
using Personnel.Amy.Model;

namespace Personnel.Amy.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BBook bll = new BBook();
            MBook model = new MBook();
            model.Name = "操作系统";
            model.Author = "不知道了";
            model.Press = 2;
            model.PressDateTime = new DateTime(1990, 10, 1);
            model.IsRead = 1;
            bool ret = bll.AddBook(model);
            Assert.AreEqual(ret, true);
        }
    }
}
