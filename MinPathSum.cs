public class Solution {
    public int MinPathSum(int[][] grid) {
        int lastRow = grid.Length - 1;
        int lastCol = grid[0].Length - 1;
        
        int[,] pathSums = new int[lastRow + 1, lastCol + 1];
        
        for (int i = lastRow; i >= 0; --i) {
            for (int j = lastCol; j >= 0; --j) {
                if (i == lastRow && j == lastCol) {
                    pathSums[i, j] = grid[i][j];
                }
                else if (i == lastRow) {
                    pathSums[i, j] = grid[i][j] + pathSums[i, j + 1];
                }
                else if (j == lastCol) {
                    pathSums[i, j] = grid[i][j] + pathSums[i + 1, j];
                }
                else {
                    pathSums[i, j] = grid[i][j] + Math.Min(pathSums[i + 1, j], pathSums[i, j + 1]);
                }
            }
        }
        
        return pathSums[0, 0];
    }
}