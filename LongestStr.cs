using System;
namespace LongestSubtring
{
    public class Program
    {
        static string[] LongestSubstring(string inputString, out int maxLength)
        {
            string currentString = "";
            string[] longestStrings = new string[inputString.Length];
            for (int i = 0; i < inputString.Length; i++) { longestStrings[i] = ""; }
            int countStrings = 0;
            maxLength = 0;
            foreach (char character in inputString)
            {
                int currentIndex = currentString.IndexOf(character);
                if (currentIndex == -1)
                {
                    currentString += character;
                    longestStrings[countStrings] = currentString;
                }
                else
                {
                    longestStrings[countStrings] = currentString;
                    countStrings += 1;
                    currentString = currentString.Substring(currentIndex + 1) + character;
                }

            }
            for (int i = 0; i < longestStrings.Length; i += 1)
            {
                if (longestStrings[i].Length > maxLength)
                { maxLength = longestStrings[i].Length; }
            }

            return longestStrings;
        }
        // public static void Main(string[] args)
        // {
        //     string inputString = "lovedeathrobot";
        //     string[] longestStrings = LongestSubstring(inputString, out int maxLength);
        //     foreach (var substring in longestStrings)
        //     {
        //         if (substring.Length == maxLength)
        //         {
        //             Console.WriteLine(substring);
        //         }
        //     }
        // }
    }
}
