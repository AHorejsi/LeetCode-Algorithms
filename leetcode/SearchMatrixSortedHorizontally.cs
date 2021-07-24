public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int rowCount = matrix.Length;
        int colCount = matrix[0].Length;
        int size = rowCount * colCount;
        
        int left = 0;
        int right = size - 1;
        
        while (left <= right) {
            int mid = (left + right) / 2;
            
            int rowIndex = mid / colCount;
            int colIndex = mid % colCount;
            
            if (target == matrix[rowIndex][colIndex]) {
                return true;
            }
            else if (target < matrix[rowIndex][colIndex]) {
                right = mid - 1;
            }
            else {
                left = mid + 1;
            }
        }
        
        return false;
    }
}