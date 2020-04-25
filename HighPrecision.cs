using System;
namespace HighPrecisionOperations
{
    public class Program
    {
        public static string HighPrecisionAdd(string numberString1, string numberString2)
        {
            int maxLength = Math.Max(numberString1.Length, numberString2.Length);
            int[] number1 = new int[maxLength], number2 = new int[maxLength];
            int[] sum = new int[maxLength];

            for (int i = numberString1.Length - 1; i >= 0; i -= 1)
            {
                number1[maxLength + i - numberString1.Length] = int.Parse(numberString1[i].ToString());
            }
            for (int i = numberString2.Length - 1; i >= 0; i -= 1)
            {
                number2[maxLength + i - numberString2.Length] = int.Parse(numberString2[i].ToString());
            }

            string sumString = "";
            int carry = 0;
            for (int i = sum.Length - 1; i >= 0; i -= 1)
            {
                sum[i] = number1[i] + number2[i] + carry;
                carry = sum[i] / 10;
                sum[i] %= 10;
                sumString = sum[i].ToString() + sumString;
            }
            if (carry == 1) { sumString = "1" + sumString; }

            return sumString;
        }
        public static string HighPrecisionMultiply(string numberString1, string numberString2)
        {
            int maxLength = numberString1.Length + numberString2.Length;
            int[] number1 = new int[numberString1.Length], number2 = new int[numberString2.Length];
            int[] product = new int[maxLength];

            for (int i = numberString1.Length - 1; i >= 0; i -= 1)
            {
                number1[i] = int.Parse(numberString1[i].ToString());
            }
            for (int i = numberString2.Length - 1; i >= 0; i -= 1)
            {
                number2[i] = int.Parse(numberString2[i].ToString());
            }

            int tempProducts = 0;
            for (int i = number1.Length - 1; i >= 0; i -= 1)
            {
                for (int j = number2.Length - 1; j >= 0; j -= 1)
                {
                    tempProducts = number1[i] * number2[j] + product[i + j + 1];
                    product[i + j + 1] = tempProducts % 10;
                    product[i + j] += tempProducts / 10;
                }
            }

            string productString = "";
            int startIndex = 0;
            for (int i = 0; i < maxLength; i += 1) { if (product[i] != 0) { startIndex = i; break; } }
            for (int i = startIndex; i < maxLength; i += 1) { productString += product[i].ToString(); }
            return productString;
        }

        // static void Main()
        // {
        //     string numberString1 = "3";
        //     string numberString2 = "5";
        //     string sumString = HighPrecisionAdd(numberString1, numberString2);
        //     Console.WriteLine("Sum of the two numbers is {0}", sumString);
        //     string productString = HighPrecisionMultiply(numberString1, numberString2);
        //     Console.WriteLine("Product of the two numbers is {0}", productString);
        // }
    }
}