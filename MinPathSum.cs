public class Solution {
    public int MinPathSum(int[][] grid) {
        int[,] pathSums = new int[grid.Length, grid[0].Length];
        
        for (int i = pathSums.GetLength(0) - 1; i >= 0; --i) {
            for (int j = pathSums.GetLength(1) - 1; j >= 0; --j) {
                if (i == pathSums.GetLength(0) - 1 && j == pathSums.GetLength(1) - 1) {
                    pathSums[i, j] = grid[i][j];
                }
                else if (i != pathSums.GetLength(0) - 1 && j == pathSums.GetLength(1) - 1) {
                    pathSums[i, j] = grid[i][j] + pathSums[i + 1, j];
                }
                else if (i == pathSums.GetLength(0) - 1 && j != pathSums.GetLength(1) - 1) {
                    pathSums[i, j] = grid[i][j] + pathSums[i, j + 1];
                }
                else {
                    pathSums[i, j] = grid[i][j] + Math.Min(pathSums[i + 1, j], pathSums[i, j + 1]);
                }
            }
        }
        
        return pathSums[0, 0];
    }
}