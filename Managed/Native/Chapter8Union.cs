using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Managed.Native
{
    public enum Ch8DataType : int
    {
        INT,
        DOUBLE,
        CH8SAMPLE,
    }

    [StructLayout(LayoutKind.Explicit)]
    public class Ch8Sample
    {
        [FieldOffset(0)]
        public int iValue = 123;
        [FieldOffset(0)]
        public double dValue = 123.123;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch8ComplexCh8Sample
    {
        [MarshalAs(UnmanagedType.Struct)]
        public Ch8Sample ch8SampleValue = new Ch8Sample();
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch8ComplexINT
    {
        public int iValue = 123;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch8StructWithUnionINT
    {
        [MarshalAs(UnmanagedType.I4)]
        private Ch8DataType ch8DataType = Ch8DataType.INT;

        /// <summary>
        /// In c code InneralUnion is 8 byte alignment so append here 4 byte
        /// </summary>
        private int reserved = -1;

        public int iValue = 123;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Ch8StructWithUnionINT2
    {
        [MarshalAs(UnmanagedType.I4)]
        public Ch8DataType ch8DataType;

        /// <summary>
        /// In c code InneralUnion is 8 byte alignment so append here 4 byte
        /// </summary>
        private int reserved;

        public int iValue;

        private int reserved1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch8StructWithUnionCh8Sample
    {
        [MarshalAs(UnmanagedType.I4)]
        private Ch8DataType ch8DataType = Ch8DataType.CH8SAMPLE;

        [MarshalAs(UnmanagedType.Struct)]
        public Ch8Sample ch8SampleValue = new Ch8Sample();
    }

    public class Ch8Native
    {
        const string DLLNAME = "Native.dll";

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch8ModifyCh8Sample([In, Out]Ch8Sample value, Ch8DataType ch8DataType);

        [DllImport(DLLNAME, EntryPoint = "Ch8ModifyCh8Complex", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch8ModifyCh8ComplexCh8Sample([In, Out]Ch8ComplexCh8Sample value, Ch8DataType ch8DataType);

        [DllImport(DLLNAME, EntryPoint = "Ch8ModifyCh8Complex", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch8ModifyCh8ComplexINT([In, Out]Ch8ComplexINT value, Ch8DataType ch8DataType);

        [DllImport(DLLNAME, EntryPoint = "Ch8ModifyCh8StructWithUnion", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch8ModifyCh8StructWithUnionINT([In, Out]Ch8StructWithUnionINT value);

        [DllImport(DLLNAME, EntryPoint = "Ch8ModifyCh8StructWithUnion", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch8ModifyCh8StructWithUnionCh8Sample([In, Out]Ch8StructWithUnionCh8Sample value);

        [DllImport(DLLNAME, EntryPoint = "Ch8ModifyCh8StructWithUnionByValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch8ModifyCh8StructWithUnionByValue([MarshalAs(UnmanagedType.Struct)]Ch8StructWithUnionINT2 value);

        [DllImport(DLLNAME, EntryPoint = "_Ch8ModifyCh8StructWithUnionByValueStd@16", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Ch8ModifyCh8StructWithUnionByValueStd([MarshalAs(UnmanagedType.Struct)] Ch8StructWithUnionINT2 value);
    }

    public class Ch8Test
    {
        public static void Ch8ModifyCh8Sample()
        {
            bool ret = false;
            var value = new Ch8Sample();

            value.iValue = 123;
            ret = Ch8Native.Ch8ModifyCh8Sample(value, Ch8DataType.INT);

            value.dValue = 123.123;
            ret = Ch8Native.Ch8ModifyCh8Sample(value, Ch8DataType.DOUBLE);
        }

        public static void Ch8ModifyCh8ComplexCh8Sample()
        {
            bool ret = false;
            var value = new Ch8ComplexCh8Sample();
            value.ch8SampleValue.dValue = 123.123;
            ret = Ch8Native.Ch8ModifyCh8ComplexCh8Sample(value, Ch8DataType.CH8SAMPLE);
        }

        public static void Ch8ModifyCh8ComplexINT()
        {
            bool ret = false;
            var value = new Ch8ComplexINT();
            value.iValue = 123;
            ret = Ch8Native.Ch8ModifyCh8ComplexINT(value, Ch8DataType.INT);
        }

        public static void Ch8ModifyCh8StructWithUnionINT()
        {
            var value = new Ch8StructWithUnionINT();
            value.iValue = 123;
            bool ret = Ch8Native.Ch8ModifyCh8StructWithUnionINT(value);
        }

        public static void Ch8ModifyCh8StructWithUnionCh8Sample()
        {
            var value = new Ch8StructWithUnionCh8Sample();
            bool ret = Ch8Native.Ch8ModifyCh8StructWithUnionCh8Sample(value);
        }

        public static void Ch8ModifyCh8StructWithUnionByValue()
        {
            Ch8StructWithUnionINT2 value = new Ch8StructWithUnionINT2
            {
                iValue = 123,
                ch8DataType = Ch8DataType.INT
            };
            bool ret = Ch8Native.Ch8ModifyCh8StructWithUnionByValue(value);
        }

        public static void Ch8ModifyCh8StructWithUnionByValueStd()
        {
            Ch8StructWithUnionINT2 value = new Ch8StructWithUnionINT2
            {
                iValue = 123,
                ch8DataType = Ch8DataType.INT
            };
            bool ret = Ch8Native.Ch8ModifyCh8StructWithUnionByValueStd(value);
        }
    }
}
