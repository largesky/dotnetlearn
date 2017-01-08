using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace Managed.Native
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Ch10Dog
    {
        public int iValue;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string wsValue;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Ch10DogArrivedHandler(long count, [MarshalAs(UnmanagedType.LPWStr)] string time, Ch10Dog dog);

    public class Ch10Native
    {
        const string DLLNAME = "Native.dll";

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool StartDetect(Ch10DogArrivedHandler handler);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool StopDetect();
    }

    public class Ch10Test
    {
        private static readonly Ch10DogArrivedHandler hander = new Ch10DogArrivedHandler(Ch10DogArrivedHandler);

        public static void Test()
        {
            Ch10Native.StartDetect(hander);
            Console.Read();
            Ch10Native.StopDetect();
        }

        private static void Ch10DogArrivedHandler(long count,string time, Ch10Dog dog)
        {
            Console.WriteLine(string.Format("Count:{0}, Time:{1}, Dog:{2}", count, time, dog.wsValue));
        }
    }
}
