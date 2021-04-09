public class Solution {    
    public int UniquePaths(int rows, int cols) {
        int[,] count = this.initializeCounts(rows, cols);
        
        for (int i = 1; i < rows; i++) { 
            for (int j = 1; j < cols; j++) {
                count[i, j] = count[i - 1, j] + count[i, j - 1];
            }
        }
        
        return count[rows - 1, cols - 1]; 
    }
    
    private int[,] initializeCounts(int rows, int cols) {
        int[,] count = new int[rows, cols];
        
        for (int i = 0; i < rows; i++) {
            count[i, 0] = 1; 
        }
        
        for (int j = 0; j < cols; j++) {
            count[0, j] = 1;
        }
        
        return count;
    }
}