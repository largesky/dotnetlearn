using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Managed.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public class Ch12Bitable
    {
        public int iValue = 123;
        public double dValue = 123.123;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch12NonBitable
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] iaValue = new int[] { 123, 123, 123, 123 };
    }

    public class Ch12Native
    {
        const string DLLNAME = "Native.dll";

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch12ModifyCh12Bitable(Ch12Bitable value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch12ModifyCh12NonBitable(Ch12NonBitable value);

        [DllImport(DLLNAME, EntryPoint = "Ch12ModifyCh12NonBitable", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch12ModifyCh12NonBitableWithOut([In, Out]Ch12NonBitable value);
    }

    public class Ch12Test
    {
        public static void Ch12ModifyCh12Bitable()
        {
            var value = new Ch12Bitable();
            bool ret = Ch12Native.Ch12ModifyCh12Bitable(value);
        }

        public static void Ch12ModifyCh12NonBitable()
        {
            var value = new Ch12NonBitable();
            bool ret = Ch12Native.Ch12ModifyCh12NonBitable(value);
        }

        public static void Ch12ModifyCh12NonBitableWithOut()
        {
            var value = new Ch12NonBitable();
            bool ret = Ch12Native.Ch12ModifyCh12NonBitableWithOut(value);
        }
    }
}
