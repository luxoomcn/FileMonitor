using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace text
{
    [TestFixture]
    public class Runtext
    {
        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "找不到路径：D:/")]
        public void RunText()
        {
           
            MyFileSystemWather.Instance.Run(new string[] {"D:/" });

           // Assert.IsNull(MyFileSystemWather.Instance::, "exception:找不到路径：D:/");

        }
    }

}
