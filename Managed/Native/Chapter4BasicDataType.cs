using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace Managed.Native
{
    public class Chapter4Native
    {
        const string DLLNAME = "Native.dll";

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch4_ModifyBasicDataType(int iValue, ref double dValue, ref uint dwValue);
    }

    public class Ch4Test
    {
        public static void Ch4_ModifyBasicDataType()
        {
            int iValue = 123;
            double dValue = 123;
            uint dwValue = 123;

            bool ret = Chapter4Native.Ch4_ModifyBasicDataType(iValue, ref dValue, ref dwValue);
        }
    }
}
