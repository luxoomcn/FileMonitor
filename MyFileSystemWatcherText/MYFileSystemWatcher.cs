using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Collections;

namespace text
{
    public delegate void Completed(string key);

    public sealed  class MyFileSystemWather
    {
        private FileSystemWatcher fsWather;
        private Hashtable hstbWather;

        private string pathFile;
        private string filterFile;
        public event RenamedEventHandler OnRenamed;
        public event FileSystemEventHandler OnChanged;
        public event FileSystemEventHandler OnCreated;
        public event FileSystemEventHandler OnDeleted;
        public  void Run(string[] ss)
        {
            foreach (string s in ss)
            {
                MyFileSystemWather.instance.check();
                MyFileSystemWather.instance.setPath(s);
                MyFileSystemWather.instance.setFilter("*.*");
                MyFileSystemWather.instance.Start();
            }
        }
        
        public void  setPath(string path1)
        {
            pathFile = path1;
        }
        public void setFilter(string filte1)
        {
            filterFile = filte1;
        }
        public void check() {
            Console.WriteLine("The path of the mointor file: {0} {1}", pathFile, filterFile);
        }
        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="path">要监控的路径</param> 
       private static readonly MyFileSystemWather instance = new MyFileSystemWather( );
        public static MyFileSystemWather Instance 
         { 
            get  
               { 
                return instance;  
               } 
              
           } 
        private MyFileSystemWather( )
        {
        }
        /// <summary> 
        /// 开始监控 
        /// </summary> 
        public void Start()
        {
            if (!Directory.Exists(pathFile))
            {
                throw new Exception("找不到路径：" + pathFile);
            }

            hstbWather = new Hashtable();

            fsWather = new FileSystemWatcher(pathFile);
            // 是否监控子目录
            fsWather.IncludeSubdirectories = true;
            fsWather.Filter = filterFile;
            fsWather.Renamed += new RenamedEventHandler(fsWather_Renamed);
            fsWather.Changed += new FileSystemEventHandler(fsWather_Changed);
            fsWather.Created += new FileSystemEventHandler(fsWather_Created);
            fsWather.Deleted += new FileSystemEventHandler(fsWather_Deleted);
            // fsWather.EnableRaisingEvents = true;
            // fsWather.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess
            //                       | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            // fsWather.IncludeSubdirectories = true;
            fsWather.EnableRaisingEvents = true;
        }

        /// <summary> 
        /// 停止监控 
        /// </summary> 
       /* public void Stop()
        {
            fsWather.EnableRaisingEvents = false;
        }*/

        /// <summary> 
        /// filesystemWatcher 本身的事件通知处理过程 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void fsWather_Renamed(object sender, RenamedEventArgs e)
        {
            lock (hstbWather)                                                        //To ensure that when a thread located in the critical section of code , another thread enters the critical section

            {
                hstbWather.Add(e.FullPath, e);                                       //Adds an element with the specified key and value into the Hashtable.
            }

            WatcherProcess watcherProcess = new WatcherProcess(sender, e);
            watcherProcess.OnCompleted += new Completed(WatcherProcess_OnCompleted);//Remove the corresponding change file Hashtable key , or the next change of this file can not be triggered your business logic .

            watcherProcess.OnRenamed += new RenamedEventHandler(WatcherProcess_OnRenamed);
            Thread thread = new Thread(watcherProcess.Process);                      //Initializes a new instance of the Thread class, specifying a delegate that allows an object to be passed to the thread when the thread is started.
            thread.Start();                                                         //Causes a thread to wait the number of times defined by the iterations parameter.
        }

        private void WatcherProcess_OnRenamed(object sender, RenamedEventArgs e)
        {
            OnRenamed(sender, e);
        }

        private void fsWather_Created(object sender, FileSystemEventArgs e)
        {
            lock (hstbWather)
            {
                hstbWather.Add(e.FullPath, e);
            }
            WatcherProcess watcherProcess = new WatcherProcess(sender, e);
            watcherProcess.OnCompleted += new Completed(WatcherProcess_OnCompleted);
            watcherProcess.OnCreated += new FileSystemEventHandler(WatcherProcess_OnCreated);
            Thread threadDeal = new Thread(watcherProcess.Process);
            threadDeal.Start();
        }

        private void WatcherProcess_OnCreated(object sender, FileSystemEventArgs e)
        {
            OnCreated(sender, e);
        }

        private void fsWather_Deleted(object sender, FileSystemEventArgs e)
        {
            lock (hstbWather)
            {
                hstbWather.Add(e.FullPath, e);
            }
            WatcherProcess watcherProcess = new WatcherProcess(sender, e);
            watcherProcess.OnCompleted += new Completed(WatcherProcess_OnCompleted);
            watcherProcess.OnDeleted += new FileSystemEventHandler(WatcherProcess_OnDeleted);
            Thread tdDeal = new Thread(watcherProcess.Process);
            tdDeal.Start();
        }

        private void WatcherProcess_OnDeleted(object sender, FileSystemEventArgs e)
        {
            OnDeleted(sender, e);
        }

        private void fsWather_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                if (hstbWather.ContainsKey(e.FullPath))
                {
                    WatcherChangeTypes oldType = ((FileSystemEventArgs)hstbWather[e.FullPath]).ChangeType;
                    if (oldType == WatcherChangeTypes.Created || oldType == WatcherChangeTypes.Changed)
                    {
                        return;
                    }
                }
            }

            lock (hstbWather)
            {
                hstbWather.Add(e.FullPath, e);
            }
            WatcherProcess watcherProcess = new WatcherProcess(sender, e);
            watcherProcess.OnCompleted += new Completed(WatcherProcess_OnCompleted);
            watcherProcess.OnChanged += new FileSystemEventHandler(WatcherProcess_OnChanged);
            Thread thread = new Thread(watcherProcess.Process);
            thread.Start();
        }

        private void WatcherProcess_OnChanged(object sender, FileSystemEventArgs e)
        {
            OnChanged(sender, e);
        }

        public void WatcherProcess_OnCompleted(string key)
        {
            lock (hstbWather)
            {
                hstbWather.Remove(key);
            }
        }
    }
}
