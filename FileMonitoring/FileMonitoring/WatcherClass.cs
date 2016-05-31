using System;
using System.IO;
using System.Security.Permissions;

namespace FileMonitoring
{
    class WatcherClass
    {
        public static void Main()
        {
            Run();
        }

        [PermissionSet(SecurityAction.Demand, Name ="FullTrust")]

        public static void Run()
        {
            string[] args = System.Environment.GetCommandLineArgs();

            if(args.Length != 2)
            {
                Console.WriteLine("Usage: WatcherClass.exe (directory)");
                return;
            }

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = args[1];
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = ""; 

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.Error += new ErrorEventHandler(OnError);
            
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press \'q\' to quit the program.");
            while (Console.Read() != 'q') ;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            WatcherChangeTypes wct = e.ChangeType;
            Console.WriteLine("File {0} {1} {2}", e.Name, e.FullPath,  wct.ToString());
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            WatcherChangeTypes wct = e.ChangeType;
            Console.WriteLine("File {0} {1} {4} to {2} {3}", e.OldName, e.OldFullPath, e.Name, e.FullPath, wct.ToString());
        }

        private static void OnError(object source, ErrorEventArgs e)
        {
            Console.WriteLine("The FileSystemWatcher has detected an error");

            if(e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }

    }
}
