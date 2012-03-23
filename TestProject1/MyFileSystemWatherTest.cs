using text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TypeMock.ArrangeActAssert;


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
           // Assert.IsNull(checkTest());
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
        [ExpectedException(typeof(Exception), "找不到路径")]
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
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FileSystemEventArgs e = null; // TODO: Initialize to an appropriate value
            target.WatcherProcess_OnChanged(sender, e);
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
           
        }

        /// <summary>
        ///A test for WatcherProcess_OnCompleted
        ///</summary>
        [TestMethod()]
        public void WatcherProcess_OnCompletedTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            target.WatcherProcess_OnCompleted(key);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WatcherProcess_OnCreated
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void WatcherProcess_OnCreatedTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FileSystemEventArgs e = null; // TODO: Initialize to an appropriate value
            target.WatcherProcess_OnCreated(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WatcherProcess_OnDeleted
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void WatcherProcess_OnDeletedTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FileSystemEventArgs e = null; // TODO: Initialize to an appropriate value
            target.WatcherProcess_OnDeleted(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for WatcherProcess_OnRenamed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void WatcherProcess_OnRenamedTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            RenamedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.WatcherProcess_OnRenamed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for fsWather_Changed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void fsWather_ChangedTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FileSystemEventArgs e = null; // TODO: Initialize to an appropriate value
            target.fsWather_Changed(sender, e);
            
           // Assert.Inconclusive("A method that does not return a value cannot be verified.");
            
        }
        /// <summary>
        ///A test for fsWather_Created
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void fsWather_CreatedTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FileSystemEventArgs e = null; // TODO: Initialize to an appropriate value
            target.fsWather_Created(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for fsWather_Deleted
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void fsWather_DeletedTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            FileSystemEventArgs e = null; // TODO: Initialize to an appropriate value
            target.fsWather_Deleted(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for fsWather_Renamed
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MyFileSystemWatcherText.dll")]
        public void fsWather_RenamedTest()
        {
            MyFileSystemWather_Accessor target = new MyFileSystemWather_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            RenamedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.fsWather_Renamed(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
