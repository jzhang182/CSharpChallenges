using System;
using System.Linq;

namespace ReverseString
{
    public class Program
    {
        public static string ReverseAndNot(int i)
        {
            char[] array = i.ToString().ToCharArray();
            Array.Reverse(array);
            string reversedString = new string(array);
            return reversedString + i.ToString();
        }
        // public static void Main()
        // {
        //     int integer = 123;
        //     string sealedString = ReverseAndNot(integer);
        //     Console.WriteLine($"{sealedString}");
        // }
    }
}