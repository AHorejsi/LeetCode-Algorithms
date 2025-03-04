public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int rowIndex = 0;
        int colIndex = matrix[0].Length - 1;
        
        // As traversal goes on, any values with a column index greater
        // than "colIndex" and any values with a row index less than
        // "rowIndex" are ignored
        while (matrix.Length != rowIndex && -1 != colIndex) {
            int value = matrix[rowIndex][colIndex];
            
            if (target < value) {
                // All values in the current column are greater than "target",
                // not counting previously ignored values
                
                --colIndex;
            }
            else if (target > value) {
                // All values in the current row are less than "target", not
                // counting previously ignored values
                
                ++rowIndex;
            }
            else {
                return true;
            }
        }
        
        return false;
    }
}
