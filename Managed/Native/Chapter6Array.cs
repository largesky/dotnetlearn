using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Managed.Native
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Ch6Dog
    {
        public int age;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string name;
    }

    public class Ch6Native
    {
        const string DLLNAME = "Native.dll";

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch6ModifyArrayInt([In, Out]int[] values);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool Ch6ModifyArrayChar([In, Out] char[] values);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch6ModifyArrayCh6Dog([In, Out]Ch6Dog[] values);
    }

    public class Ch6Test
    {
        public static void Ch6ModifyArrayInt()
        {
            var values = new int[5];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = 123;
            }
            bool ret = Ch6Native.Ch6ModifyArrayInt(values);
        }

        public static void Ch6ModifyArrayChar()
        {
            var values = new char[5];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = 'B';
            }
            bool ret = Ch6Native.Ch6ModifyArrayChar(values);
        }

        public static void Ch6ModifyArrayDog()
        {
            var values = new Ch6Dog[5];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = new Ch6Dog
                {
                    age = 123,
                    name = "狗".PadRight(5, (char)0)
                };
            }
            bool ret = Ch6Native.Ch6ModifyArrayCh6Dog(values);
        }
    }
}
