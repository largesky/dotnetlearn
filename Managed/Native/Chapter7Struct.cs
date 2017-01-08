using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Managed.Native
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Ch7Basic
    {
        public int iValue = 123;

        public double dValue = 123.123;

        [MarshalAs(UnmanagedType.Bool)]
        public bool bWinValue = false;

        [MarshalAs(UnmanagedType.I1)]
        public bool bValue = false;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class Ch7CharA
    {
        public char acValue1 = 'B';
        public char acValue2 = 'B';
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch7CharAW
    {
        [MarshalAs(UnmanagedType.U2)]
        public char wcValue = '你';

        [MarshalAs(UnmanagedType.U1)]
        public char acValue = 'B';
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class Ch7StringA
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string asValue1 = "BBBB".PadRight(4, (char)0);

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string asValue2 = "BBBB".PadRight(4, (char)0);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Ch7StringAW
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U2, SizeConst = 4)]
        public char[] wsValue;

        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 4)]
        public char[] asValue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch7StringPtr
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwsValue = "你你你你";

        [MarshalAs(UnmanagedType.LPStr)]
        public string pasValue = "BBBB";
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch7Struct
    {
        [MarshalAs(UnmanagedType.Struct)]
        public Ch7StringAW ch7StringAW;

        public Ch7Struct()
        {
            this.ch7StringAW = new Ch7StringAW
            {
                asValue = "BBBB".PadRight(4, (char)0).ToArray(),
                wsValue = "你你你你".PadRight(4, (char)0).ToArray(),
            };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch7StructArray
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 4)]
        public Ch7StringAW[] ch7StringAWArray;

        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 4)]
        public int[] iArray;

        public Ch7StructArray()
        {
            this.ch7StringAWArray = new Ch7StringAW[4];
            for (int i = 0; i < this.ch7StringAWArray.Length; i++)
            {
                this.ch7StringAWArray[i] = new Ch7StringAW
                {
                    asValue = "BBBB".PadRight(4, (char)0).ToArray(),
                    wsValue = "你你你你".PadRight(4, (char)0).ToArray(),
                };
            }
            this.iArray = new int[] { 123, 123, 123, 123 };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch7Pointer
    {
        public IntPtr ch7StringAWPtr = IntPtr.Zero;
        public IntPtr iValuePtr = IntPtr.Zero;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Ch7PointerArray
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public IntPtr[] pchStringAWPtrArray = new IntPtr[4];

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public IntPtr[] iValuePtrArray = new IntPtr[4];
    }

    public class Ch7Native
    {
        const string DLLNAME = "Native.dll";

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7Basic([In, Out]Ch7Basic value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7CharA([In, Out]Ch7CharA value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7CharAW([In, Out]Ch7CharAW value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7StringA([In, Out]Ch7StringA value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7StringAW(ref Ch7StringAW value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7StringPtr([In, Out]Ch7StringPtr value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7Struct([In, Out]Ch7Struct value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7StructArray([In, Out]Ch7StructArray value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7Pointer([In, Out]Ch7Pointer value);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Ch7ModifyCh7PointerArray(Ch7PointerArray value);
    }

    public class Ch7Test
    {
        public static void Ch7ModifyCh7Basic()
        {
            var value = new Ch7Basic();
            bool ret = Ch7Native.Ch7ModifyCh7Basic(value);
        }

        public static void Ch7ModifyCh7CharA()
        {
            var value = new Ch7CharA();
            bool ret = Ch7Native.Ch7ModifyCh7CharA(value);
        }

        public static void Ch7ModifyCh7CharAW()
        {
            var value = new Ch7CharAW();
            bool ret = Ch7Native.Ch7ModifyCh7CharAW(value);
        }

        public static void Ch7ModifyCh7StringA()
        {
            var value = new Ch7StringA();
            bool ret = Ch7Native.Ch7ModifyCh7StringA(value);
        }

        public static void Ch7ModifyCh7StringAW()
        {
            var value = new Ch7StringAW
            {
                asValue = "BBBB".PadRight(4, (char)0).ToArray(),
                wsValue = "你你你你".PadRight(4, (char)0).ToArray(),
            };
            bool ret = Ch7Native.Ch7ModifyCh7StringAW(ref value);
        }

        public static void Ch7ModifyCh7StringPtr()
        {
            var value = new Ch7StringPtr();
            bool ret = Ch7Native.Ch7ModifyCh7StringPtr(value);
        }

        public static void Ch7ModifyCh7Struct()
        {
            var value = new Ch7Struct();
            bool ret = Ch7Native.Ch7ModifyCh7Struct(value);
        }

        public static void Ch7ModifyCh7StructArray()
        {
            var value = new Ch7StructArray();
            bool ret = Ch7Native.Ch7ModifyCh7StructArray(value);
        }

        public static void Ch7ModifyCh7Pointer()
        {
            //create objects to use
            var value = new Ch7Pointer();
            var ch7StringAW = new Ch7StringAW
            {
                asValue = "BBBB".ToArray(),
                wsValue = "你你你你".ToArray(),
            };
            int iValue = 123;

            //alloc memory from process heap
            value.ch7StringAWPtr = Marshal.AllocHGlobal(Marshal.SizeOf(ch7StringAW));
            value.iValuePtr = Marshal.AllocHGlobal(Marshal.SizeOf(iValue));

            //copy managed object memory to native heap
            Marshal.StructureToPtr(ch7StringAW, value.ch7StringAWPtr, false);
            Marshal.StructureToPtr(iValue, value.iValuePtr, false);

            //call method
            if (Ch7Native.Ch7ModifyCh7Pointer(value))
            {
                //copy native heap to managed object memory
                ch7StringAW = (Ch7StringAW)Marshal.PtrToStructure(value.ch7StringAWPtr, typeof(Ch7StringAW));
                iValue = (int)Marshal.PtrToStructure(value.iValuePtr, typeof(int));
            }
            //do not forgot free native heap memory
            Marshal.FreeHGlobal(value.ch7StringAWPtr);
            Marshal.FreeHGlobal(value.iValuePtr);

            value.ch7StringAWPtr = IntPtr.Zero;
            value.iValuePtr = IntPtr.Zero;
        }

        public static void Ch7ModifyCh7PointerArray()
        {
            //create objects to use
            var value = new Ch7PointerArray();
            int[] iValues = new int[] { 123, 123, 123, 123 };
            Ch7StringAW[] ch7StringAWs = new Ch7StringAW[4];

            for (int i = 0; i < ch7StringAWs.Length; i++)
            {
                ch7StringAWs[i] = new Ch7StringAW
                {
                    asValue = "BBBB".ToArray(),
                    wsValue = "你你你你".ToArray(),
                };
            }

            //alloc memory from process heap
            for (int i = 0; i < 4; i++)
            {
                value.iValuePtrArray[i] = Marshal.AllocHGlobal(sizeof(int));
                value.pchStringAWPtrArray[i] = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Ch7StringAW)));
            }

            //copy managed object memory to native heap
            for (int i = 0; i < 4; i++)
            {
                Marshal.StructureToPtr(iValues[i], value.iValuePtrArray[i], false);
                Marshal.StructureToPtr(ch7StringAWs[i], value.pchStringAWPtrArray[i], false);
            }

            if (Ch7Native.Ch7ModifyCh7PointerArray(value))
            {
                for (int i = 0; i < 4; i++)
                {
                    ch7StringAWs[i] = (Ch7StringAW)Marshal.PtrToStructure(value.pchStringAWPtrArray[i], typeof(Ch7StringAW));
                    iValues[i] = (int)Marshal.PtrToStructure(value.iValuePtrArray[i], typeof(int));
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Marshal.FreeHGlobal(value.iValuePtrArray[i]);
                Marshal.FreeHGlobal(value.pchStringAWPtrArray[i]);

                value.iValuePtrArray[i] = IntPtr.Zero;
                value.pchStringAWPtrArray[i] = IntPtr.Zero;
            }
        }

        public static void Ch7ModifyCh7PointerArray2()
        {
            //create objects to use
            var value = new Ch7PointerArray();
            int[] iValues = new int[] { 123, 123, 123, 123 };
            Ch7StringAW[] ch7StringAWs = new Ch7StringAW[4];

            for (int i = 0; i < ch7StringAWs.Length; i++)
            {
                ch7StringAWs[i] = new Ch7StringAW
                {
                    asValue = "BBBB".ToArray(),
                    wsValue = "你你你你".ToArray(),
                };
            }

            //alloc block memory from process heap
            IntPtr ptrIValues = Marshal.AllocHGlobal(4 * 4);
            IntPtr ptrCh7StringAW = Marshal.AllocHGlobal(4 * Marshal.SizeOf(typeof(Ch7StringAW)));

            //cal each object address
            for (int i = 0; i < 4; i++)
            {
                value.iValuePtrArray[i] = ptrIValues + i * 4;
                value.pchStringAWPtrArray[i] = ptrCh7StringAW + i * Marshal.SizeOf(typeof(Ch7StringAW));
            }

            //copy managed object memory to native heap
            for (int i = 0; i < 4; i++)
            {
                Marshal.StructureToPtr(iValues[i], value.iValuePtrArray[i], false);
                Marshal.StructureToPtr(ch7StringAWs[i], value.pchStringAWPtrArray[i], false);
            }

            if (Ch7Native.Ch7ModifyCh7PointerArray(value))
            {
                for (int i = 0; i < 4; i++)
                {
                    ch7StringAWs[i] = (Ch7StringAW)Marshal.PtrToStructure(value.pchStringAWPtrArray[i], typeof(Ch7StringAW));
                    iValues[i] = (int)Marshal.PtrToStructure(value.iValuePtrArray[i], typeof(int));
                }
            }
            Marshal.FreeHGlobal(ptrIValues);
            Marshal.FreeHGlobal(ptrCh7StringAW);
            for (int i = 0; i < 4; i++)
            {
                value.iValuePtrArray[i] = IntPtr.Zero;
                value.pchStringAWPtrArray[i] = IntPtr.Zero;
            }
            ptrCh7StringAW = IntPtr.Zero;
            ptrCh7StringAW = IntPtr.Zero;
        }
    }
}
