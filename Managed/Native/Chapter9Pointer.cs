using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Managed.Native
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Ch9Dog
    {
        public int iValue = 123;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string wsValue = "你你你你";
    }

    public class Ch9Native
    {
        const string DLLNAME = "Native.dll";

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch9AllocInt(ref IntPtr value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch9AllocCh9Dog(ref IntPtr value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Ch9AllocString();

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Ch9FreeMemory(IntPtr ptr);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch9CoTaskMemAllocCh9Dog(ref Ch9Dog value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl,CharSet=CharSet.Unicode)]
        public static extern string Ch9CoTaskMemAllocString();
    }

    public class Ch9Test
    {
        public static void Ch9AllocInt()
        {
            IntPtr value = IntPtr.Zero;
            bool ret = Ch9Native.Ch9AllocInt(ref value);
            if (ret)
            {
                int iValue = (int)Marshal.PtrToStructure(value, typeof(int));
            }
            Ch9Native.Ch9FreeMemory(value);
        }

        public static void Ch9AllocCh9Dog()
        {
            IntPtr value = IntPtr.Zero;
            if (Ch9Native.Ch9AllocCh9Dog(ref value))
            {
                Ch9Dog dog = (Ch9Dog)Marshal.PtrToStructure(value, typeof(Ch9Dog));
            }
            Ch9Native.Ch9FreeMemory(value);
        }

        public static void Ch9AllocString()
        {
            IntPtr value = Ch9Native.Ch9AllocString();
            string str = Marshal.PtrToStringUni(value);
            Ch9Native.Ch9FreeMemory(value);
        }

        public static void Ch9CoTaskMemAllocCh9Dog()
        {
            Ch9Dog dog = new Ch9Dog();
            bool ret = Ch9Native.Ch9CoTaskMemAllocCh9Dog(ref dog);
        }

        public static void Ch9CoTaskMemAllocString()
        {
            string value = Ch9Native.Ch9CoTaskMemAllocString();
        }
    }
}
