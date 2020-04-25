using System;
namespace XUnitTestProject1
{
    public class Skyline
    {
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int verticalLength = grid.Length;
            int horizonalLength = grid[0].Length;
            int[] rowMaxes = new int[verticalLength];
            int[] colMaxes = new int[horizonalLength];
            for (int row = 0; row < verticalLength; row += 1)
                for (int column = 0; column < horizonalLength; column += 1)
                {
                    rowMaxes[row] = Math.Max(rowMaxes[row], grid[row][column]);
                    colMaxes[column] = Math.Max(colMaxes[column], grid[row][column]);
                }

            int increasement = 0;
            for (int row = 0; row < verticalLength; row += 1)
                for (int column = 0; column < horizonalLength; column += 1)
                {
                    increasement += Math.Min(rowMaxes[row], colMaxes[column]) - grid[row][column];
                }
            return increasement;
        }
    }
}