public class Solution {
    public int MinPathSum(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int lastRow = rows - 1;
        int lastCol = cols - 1;
        
        int[] previousRow = new int[cols];
        int[] currentRow = new int[cols];
        
        for (int i = lastRow; i >= 0; --i) {
            int index = lastCol;
            
            for (int j = lastCol; j >= 0; --j) {
                currentRow[index] = grid[i][j];
                
                if (i != lastRow && j != lastCol) {
                    currentRow[index] += Math.Min(currentRow[index + 1], previousRow[index]);
                }
                else if (i != lastRow) {
                    currentRow[index] += previousRow[index];
                }
                else if (j != lastCol) {
                    currentRow[index] += currentRow[index + 1];
                }
                
                --index;
            }
            
            Array.Copy(currentRow, previousRow, cols);
            Array.Fill(currentRow, 0);
        }
        
        return previousRow[0];
    }
}