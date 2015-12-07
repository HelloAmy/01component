using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Julius.LoggerComponent;

namespace exeTest
{
    class Program
    {
        static void Main(string[] args)
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
