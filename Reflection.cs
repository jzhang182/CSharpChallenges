using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

class ReflectionProgram
{
    public static Dictionary<string, List<Type>> GetVisibleTypeCategoriedByNamespace(Type[] types)
    {

        Dictionary<string, List<Type>> visibleTypes = new Dictionary<string, List<Type>>();

        foreach (Type type in types)
        {
            if (type.IsVisible)
            {
                if (!visibleTypes.Keys.Contains(type.Namespace))
                {
                    visibleTypes[type.Namespace] = new List<Type>();
                }

                visibleTypes[type.Namespace].Add(type);
            }
        }

        return visibleTypes;
    }

    public static void PrintClassConstructors(Type type)
    {
        Console.WriteLine("Constructors:");
        foreach (var constructor in type.GetConstructors())
        {
            Console.Write(type.Name + " ( ");
            foreach (var parameter in constructor.GetParameters())
            {
                Console.Write(parameter.ParameterType.Name + " " + parameter.Name + ", ");
            }
            Console.WriteLine(")");
        }
    }

    public static void PrintClassMethods(Type type)
    {
        Console.WriteLine("Methods:");
        foreach (var method in type.GetMethods())
        {
            PrintClassMethod(method);
        }
    }

    public static void PrintClassMethod(MethodInfo method)
    {
        if (method.IsPublic)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Public ");
            Console.ResetColor();
        }
        if (method.IsStatic)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("static ");
            Console.ResetColor();
        }
        Console.Write(method.ReturnType.Name + " " + method.Name + " ( ");
        foreach (var parameter in method.GetParameters())
        {
            Console.Write(parameter.ParameterType.Name + " " + parameter.Name + ", ");
        }
        Console.WriteLine(")");
    }

    public static void PrintEnumFields(Type type)
    {
        foreach (var enumName in type.GetEnumNames())
        {
            Console.WriteLine(enumName);
        }
    }

    public static void Test()
    {
        Assembly myAssembly = Assembly.LoadFrom("Microsoft.CSharp.dll");
        Console.WriteLine(myAssembly.FullName);

        Type[] allTypes = myAssembly.GetTypes();

        Dictionary<string, List<Type>> visibleTypes = GetVisibleTypeCategoriedByNamespace(allTypes);

        foreach (var nameSpace in visibleTypes.Keys)
        {
            Console.WriteLine("+++++++++++++++");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Namespace: {0}", nameSpace);
            Console.ResetColor();

            foreach (var type in visibleTypes[nameSpace])
            {
                Console.WriteLine("-------------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("{1} (BaseType: {0})", type.BaseType.Name, type.Name);
                Console.ResetColor();

                if (type.IsClass)
                {
                    PrintClassConstructors(type);
                    PrintClassMethods(type);
                }

                if (type.IsEnum)
                {
                    PrintEnumFields(type);
                }

            }
        }
    }
    // static void Main()
    // {
    //     var files = Directory.GetFiles(Environment.CurrentDirectory, "*.dll");
    //     Type[] types = Assembly.LoadFrom(files[0]).GetTypes();
    //     foreach (Type type in types)
    //     {
    //         if (type.IsPublic)
    //         {
    //             MemberInfo[] members = type.GetMembers();
    //             foreach (MemberInfo member in members)
    //                 Console.WriteLine(type.Name + "." + member.Name);
    //         }
    //     }
    // }
}