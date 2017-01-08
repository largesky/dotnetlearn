using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Managed.Native
{
    class Native
    {
        public static void PrintObject(object obj, string title = "")
        {
            Console.WriteLine(string.Format("{0} object({1}) properties values :", title, obj.GetType().FullName));
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in fields)
            {
                if (field.FieldType.BaseType == typeof(Array))
                {
                    Array value = field.GetValue(obj) as Array;
                    Console.Write(field.Name + " : ");
                    foreach (var item in value)
                    {
                        Console.Write(item+" ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(string.Format("{0} : {1}", field.Name, field.GetValue(obj)));
                }
            }
        }
    }
}
