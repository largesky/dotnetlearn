using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Managed.Native
{
    public class Ch5Native
    {
        const string DLLNAME = "Native.dll";

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Ch5PrintAW([MarshalAs(UnmanagedType.LPStr)] string message, [MarshalAs(UnmanagedType.LPWStr)] string message1);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int Ch5PrintA(string message, string message1);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int Ch5PrintW(string message, string message1);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int Ch5Login(string name, string pwd, StringBuilder error);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern bool Ch5ModifyString(string str, int size);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern bool Ch5ModifyChar(ref char chr);
    }

    public class Ch5Test
    {
        public static void Ch5PrintAW()
        {
            Ch5Native.Ch5PrintAW("This is ansi string\n", "这是汉字消息\n");
        }

        public static void Ch5PrintA()
        {
            Ch5Native.Ch5PrintA("This is ansi string\n", "这是汉字消息\n");
        }

        public static void Ch5PrintW()
        {
            Ch5Native.Ch5PrintW("This is ansi string\n", "这是汉字消息\n");
        }

        public static void Ch5Login()
        {
            string name = "123";
            string pwd = "123";
            StringBuilder error = new StringBuilder(128);

            int ret = Ch5Native.Ch5Login(name, pwd, error);
        }

        public static void Ch5ModifyString()
        {
            string str1 = "Helloworld".Substring(0);
            string str2 = "Helloworld".Substring(0);

            bool ret = Ch5Native.Ch5ModifyString(str1, str1.Length);
        }

        public static void Ch5ModifyChar()
        {
            char c = 'B';
            bool ret = Ch5Native.Ch5ModifyChar(ref c);
        }
    }
}
