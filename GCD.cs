using System;
namespace XUnitTestProject1
{
    public class GCD
    {
        public int GetGCD(int numerator, int denominator)
        {
            if (numerator == 0)
            {
                return denominator;
            }
            else
            {
                return GetGCD(denominator % numerator, numerator);
            }
        }
        public string Simplify(string str)
        {
            int numerator = Convert.ToInt32(str.Split('/')[0]);
            int denominator = Convert.ToInt32(str.Split('/')[1]);
            int GreatestDevisor = GetGCD(numerator, denominator);

            return (GreatestDevisor == denominator) ? $"{numerator / denominator}"
            : $"{numerator / GreatestDevisor}/{denominator / GreatestDevisor}";
        }
    }
}