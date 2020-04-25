using System;
namespace PowerRanger
{
    public class Program
    {
        public static int PowerRanger(int power, int min, int max)
        {
            return (int)(Math.Pow(max, 1.0 / power) - Math.Pow(min, 1.0 / power) + 1);
        }
        // public static void Main()
        // {
        //     int totalNumber = PowerRanger(3, 1, 27);
        //     Console.WriteLine($"{totalNumber}");
        // }
    }
}