using System;

namespace TimeFormat
{
    public class Program
    {
        public static string ConvertTime(string time)
        {
            DateTime outputTime;
            if (time.Contains("am") || time.Contains("pm"))
            {
                DateTime.TryParse(time, out outputTime);
                return outputTime.ToString("H:mm");
            }
            else
            {
                DateTime.TryParse(time, out outputTime);
                return outputTime.ToString("h:mm tt").ToLower();
            }
        }
    }
}