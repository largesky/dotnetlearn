using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace Managed.Native
{
    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8, Size = 52)]
    //public class Dog
    //{
    //    [MarshalAs(UnmanagedType.I4)]
    //    public int age = 123;

    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
    //    public string name = "123".PadRight(24, ' ');
    //}

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Ch3Dog
    {
        public int age = 123;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public string name = "123".PadRight(24, ' ');
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Ch3DogStruct
    {
        public int age = 123;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public string name = "123".PadRight(24, ' ');
    }

    public class Ch3Native
    {
        const string DLLName = "Native.dll";

        [DllImport(DLLName, EntryPoint = "Ch3ModifyDog", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [HandleProcessCorruptedStateExceptions]
        public static extern bool Ch3ModifyDog([MarshalAs(UnmanagedType.LPStruct), In, Out] Ch3Dog dog);

        [DllImport(DLLName, EntryPoint = "Ch3ModifyDog", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [HandleProcessCorruptedStateExceptions]
        public static extern bool Ch3ModifyDogStruct([In, Out] Ch3DogStruct dog);

        [DllImport(DLLName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Ch3ModifyDog1(int iValue, ref double dValue, Ch3Dog dogValue);

        [DllImport(DLLName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Ch3ModifyDog2(int iValue, ref double dValue, [MarshalAs(UnmanagedType.Struct), In, Out] Ch3Dog dogValue);
    }

    public class Ch3Test
    {
        public static void Ch3ModifyDog()
        {
            Ch3DogStruct dog = new Ch3DogStruct();
            if (Ch3Native.Ch3ModifyDogStruct(dog) == false)
            {
                throw new Exception("Ch3_ModifyDog test fail");
            }
        }

        public static void Ch3ModifyDog1()
        {
            Ch3Dog dog = new Ch3Dog();
            double dValue = 123;
            int iValue = 123;
            if (Ch3Native.Ch3ModifyDog1(iValue,ref dValue, dog) == false)
            {
                throw new Exception("Ch3_ModifyDog test fail");
            }
        }

        public static void Ch3ModifyDog2()
        {
            Ch3Dog dog = new Ch3Dog();
            double dValue = 123;
            int iValue = 123;
            if (Ch3Native.Ch3ModifyDog2(iValue, ref dValue, dog) == false)
            {
                throw new Exception("Ch3_ModifyDog test fail");
            }
        }
    }
}
