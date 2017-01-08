using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Managed.Native;
using System.IO;
using System.Reflection;

namespace Managed
{
    //class Program
    //{
    //    static string[] GetSubDirs(string dir)
    //    {
    //        List<string> dirs = new List<string>();
    //        dirs.Add(dir);
    //        foreach (string s in System.IO.Directory.GetDirectories(dir))
    //        {
    //            dirs.Add(s);
    //            dirs.AddRange(GetSubDirs(s));
    //        }
    //        return dirs.ToArray();
    //    }

    //    public static void Main(string[] args)
    //    {
    //        string path = Environment.GetEnvironmentVariable("path");
    //        string deviceDir = System.IO.Path.Combine(new FileInfo(typeof(Program).Assembly.Location).DirectoryName, "Device");
    //        string[] subDirs = GetSubDirs(deviceDir);
    //        string newPath = subDirs.Aggregate((sum, current) => sum + ";" + current) + path;
    //        Environment.SetEnvironmentVariable("path", newPath);
    //    }
    //}



    class Program
    {
        [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions]
        public static void Main(string[] args)
        {
            Type type = typeof(Ch12Test);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (MethodInfo method in methods)
            {
                try
                {
                    method.Invoke(null, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
