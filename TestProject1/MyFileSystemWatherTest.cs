using text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using TypeMock.ArrangeActAssert;

using System.Threading;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for MyFileSystemWatherTest and is intended
    ///to contain all MyFileSystemWatherTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MyFileSystemWatherTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for setPath
        ///</summary>
        [TestMethod()]
        public void setPathTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            string path1 = "D:/"; // TODO: Initialize to an appropriate value
            target.setPath(path1);
            Assert.AreEqual(target.pathFile, "D:/");
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for setFilter
        ///</summary>
        [TestMethod()]
        public void setFilterTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            string filte1 ="*.*"; // TODO: Initialize to an appropriate value
            target.setFilter(filte1);
            Assert.AreEqual(target.filterFile, "*.*");
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for check
        ///</summary>
        [TestMethod()]
        public void checkTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            target.check();
            string path0 = @"C:\Users\Public\Pictures\Sample Pictures";
            MyFileSystemWather.Instance.Run(new string[] { path0 });
            MyFileSystemWather.Instance.check();
            //Assert.
            //Assert.IsNull(checkTest());
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception), "找不到路径")]
        public void StartTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            string path1 = "D:/"; 
            target.setPath(path1);
            target.Start();
           
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Run
        ///</summary>
        [TestMethod()]
        //[ExpectedException(typeof(Exception), "找不到路径")]
        public void RunTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            string[] ss = { @"C:\Users\Public\Pictures\Sample Pictures", @"D:\download" }; // TODO: Initialize to an appropriate value
            target.Run(ss); 
         //   Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WatcherProcess_OnChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void WatcherProcess_OnChangedTest()
        {
          //  MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            //object sender = null; // TODO: Initialize to an appropriate value
          //  FileSystemEventArgs e = null; // TODO: Initialize to an appropriate value
            //target.WatcherProcess_OnChanged(sender, e);
            //MyFileSystemWather.Instance.setPath(@"C:\download");
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
           // int i = 1;
            bool called = false;
            string pathWacher = @"C:\Users\Public\Pictures\Sample Pictures";
            string pathChanged = @"C:\Users\Public\Pictures\Sample Pictures\oldname.txt";
            MyFileSystemWather.Instance.Run(new string[] {pathWacher });
            MyFileSystemWather.Instance.OnChanged += (sender, e) => {  called = true; };
            MyFileSystemWather.Instance.OnCreated += (sender, arg) => { Thread.Sleep(100); File.AppendAllText(pathChanged, "File is created and changed!"); };
            if (!File.Exists(pathChanged))
            {
                // This statement ensures that the file is created,
                // but the handle is not kept.
                //  File.Create(path1).Close();
                FileStream fs = File.Create(pathChanged);
                fs.Close(); 
            }
            else
                File.AppendAllText(pathChanged, "File concent is changed!");
            Thread.Sleep(3000);
            Assert.IsTrue(called);

        }

        /// <summary>
        ///A test for WatcherProcess_OnCreated
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void WatcherProcess_OnCreatedTest()
        {
           /* MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FileSystemEventArgs e = null; // TODO: Initialize to an appropriate value
            target.WatcherProcess_OnCreated(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");*/
            //int i = 1;
            var called = false;
            string pathWatcher = @"C:\Users\Public\Pictures\Sample Pictures";
            string pathCreated = @"C:\Users\Public\Pictures\Sample Pictures\oldname.txt";
            if (File.Exists(pathCreated))
                File.Delete(pathCreated);
            MyFileSystemWather.Instance.Run(new string[] { pathWatcher });
            MyFileSystemWather.Instance.OnCreated += (sender, e) => { called = true; };
            if (!File.Exists(pathCreated))
                File.Create(pathCreated);
            else
            {
                File.Delete(pathCreated);   // This statement ensures that the file is created, but the handle is not kept.   
                File.Create(pathCreated);
            }
           // A:
            Thread.Sleep(200);
           // if (2 == i)
                Assert.IsTrue(called);
           // else
             //   goto A;
        }

        /// <summary>
        ///A test for WatcherProcess_OnDeleted
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void WatcherProcess_OnDeletedTest()
        {
          /*  MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FileSystemEventArgs e = null; // TODO: Initialize to an appropriate value
            target.WatcherProcess_OnDeleted(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");*/
            //int i = 1;
            var called = false;
            string pathWatcher= @"C:\Users\Public\Pictures\Sample Pictures";
            string pathDeleted = @"C:\Users\Public\Pictures\Sample Pictures\oldname.txt";
           // string path2 = @"C:\Users\Public\Pictures\Sample Pictures\newname.txt";
            MyFileSystemWather.Instance.Run(new string[] { pathWatcher });
            MyFileSystemWather.Instance.OnDeleted += (sender, e) => {  called = true; Console.WriteLine("Deleted"); };
            MyFileSystemWather.Instance.OnCreated += (sender, arg) => {Thread.Sleep(1000); File.Delete(pathDeleted); };
            if (!File.Exists(pathDeleted))
            {
                // This statement ensures that the file is created,
                // but the handle is not kept.
              //  File.Create(path1).Close();
                FileStream fs = File.Create(pathDeleted);
                fs.Close();
                //MyFileSystemWather.Instance.OnCreated += (sender, arg) => { Thread.Sleep(1000); File.Delete(path1); };
            }
            else
                File.Delete(pathDeleted);
            //  A:
            Thread.Sleep(3000);
           Assert.IsTrue(called);
         
        }

        /// <summary>
        ///A test for WatcherProcess_OnRenamed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void WatcherProcess_OnRenamedTest()
        {
           /* MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            RenamedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.WatcherProcess_OnRenamed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");*/
           // int i = 1;
            var called = false;
            string pathWatcher = @"C:\Users\Public\Pictures\Sample Pictures\oldname.txt";
            string pathRenamed = @"C:\Users\Public\Pictures\Sample Pictures\newname.txt";
            MyFileSystemWather.Instance.Run(new string[] { @"C:\Users\Public\Pictures\Sample Pictures" });
            MyFileSystemWather.Instance.OnRenamed += (sender, e) => { called = true; };
            MyFileSystemWather.Instance.OnCreated += (sender, arg) => { Thread.Sleep(1000); Microsoft.VisualBasic.FileSystem.Rename(pathWatcher, pathRenamed); };
            MyFileSystemWather.Instance.OnDeleted += (sender, arg) => { Thread.Sleep(1000); };

            if (File.Exists(pathRenamed))
            {
                File.Delete(pathRenamed);
                if (!File.Exists(pathWatcher))
                {
                    // This statement ensures that the file is created,
                    // but the handle is not kept.
                    FileStream fs = File.Create(pathWatcher);
                    fs.Close();
                }
                else
                    Microsoft.VisualBasic.FileSystem.Rename(pathWatcher, pathRenamed);
            }
            else
                if (!File.Exists(pathWatcher))
                {
                    // This statement ensures that the file is created,
                    // but the handle is not kept.
                    FileStream fs = File.Create(pathWatcher);
                    fs.Close();
                }
                else
                    Microsoft.VisualBasic.FileSystem.Rename(pathWatcher, pathRenamed);
            Thread.Sleep(2000);
                Assert.IsTrue(called);
            //else
               // goto A;
        }
        /// <summary>

        /// 修改文件名

        /// </summary>
     /*   private void ModifyFileName()
        {
           // File.Create(@"C:\Users\Public\Pictures\Sample Pictures\2\r.txt");
            File.Delete(@"C:\Users\Public\Pictures\Sample Pictures\1.txt");
           // File.Move(@"C:\Users\Public\Pictures\Sample Pictures\2\r.txt", @"C:\Users\Public\Pictures\Sample Pictures\2.txt");
            FileInfo inf=new FileInfo(@"C:\Users\Public\Pictures\Sample Pictures\2\r.txt");
            inf.MoveTo(@"C:\Users\Public\Pictures\Sample Pictures\2.txt");
            }    */
    }
}
