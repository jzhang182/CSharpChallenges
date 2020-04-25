using System;
namespace Reverse5
{
    public class Program
    {
        public static int MysteryFunc(int num)
        {
            // (832, 594);
            // (51, 36);
            // (7977, 198);
            // (1, 0);
            // (665, 99);
            // (149, 0);
            var charArray = num.ToString().ToCharArray();
            Array.Sort(charArray);
            int newNum = num - Int32.Parse(new string(charArray));
            return newNum;
        }

        // static void Main()
        // {
        //     int out1 = MysteryFunc(int.MaxValue);
        //     Console.WriteLine($"{out1}");
        // }
    }
}