using System;
namespace BinarySearch
{
    public class Program
    {
        public static int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0) { return new int[2] { -1, -1 }; }
            else
            {
                int leftIndex = 0;
                int rightIndex = nums.Length - 1;
                int leftBound, rightBound;
                int[] searchRange = new int[2];
                while (leftIndex < rightIndex)
                {
                    int midIndex = (leftIndex + rightIndex) / 2;
                    if (nums[midIndex] >= target)
                    {
                        rightIndex = midIndex;
                    }
                    else
                    {
                        leftIndex = midIndex + 1;
                    }
                }
                if (nums[leftIndex] != target)
                {
                    leftBound = -1; rightBound = -1;
                    Console.WriteLine("There's no target element in input array.");
                }
                else
                {
                    leftBound = leftIndex;

                    rightIndex = nums.Length;

                    while (leftIndex < rightIndex)
                    {
                        int midIndex = (leftIndex + rightIndex) / 2;
                        if (nums[midIndex] <= target)
                        {
                            leftIndex = midIndex + 1;
                        }
                        else
                        {
                            rightIndex = midIndex;
                        }
                    }
                    rightBound = rightIndex - 1;
                }
                searchRange = new int[2] { leftBound, rightBound };
                return searchRange;
            }
        }

        // static void Main()
        // {
        //     int[] inputArray = new int[10] { 0, 0, 2, 3, 4, 6, 7, 8, 8, 8 };
        //     int target = 0;
        //     int[] range = SearchRange(inputArray, target);
        //     Console.WriteLine($"The target range is [{range[0]}, {range[1]}]");
        // }
    }
}