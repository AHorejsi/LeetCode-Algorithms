public class Solution {
    public void SetZeroes(int[][] matrix) {
        (bool zeroInFirstRow, bool zeroInFirstCol) = this.MarkRowsAndColumns(matrix);
        this.FillRows(matrix);
        this.FillColumns(matrix);
        this.FillFirstRow(matrix, zeroInFirstRow);
        this.FillFirstColumn(matrix, zeroInFirstCol);
    }
    
    private (bool, bool) MarkRowsAndColumns(int[][] matrix) {
        bool zeroInFirstRow = false;
        bool zeroInFirstCol = false;
        
        for (int row = 0; row < matrix.Length; ++row) {
            for (int col = 0; col < matrix[row].Length; ++col) {
                if (0 == matrix[row][col]) {
                    matrix[row][0] = 0;
                    matrix[0][col] = 0;
                    
                    if (0 == row) {
                        zeroInFirstRow = true;
                    }
                    if (0 == col) {
                        zeroInFirstCol = true;
                    }
                }
            }
        }
        
        return (zeroInFirstRow, zeroInFirstCol);
    }
    
    private void FillRows(int[][] matrix) {
        for (int row = 1; row < matrix.Length; ++row) {
            if (0 == matrix[row][0]) {
                for (int col = 0; col < matrix[row].Length; ++col) {
                    matrix[row][col] = 0;
                }
            }
        }
    }
    
    private void FillColumns(int[][] matrix) {
        for (int col = 1; col < matrix[0].Length; ++col) {
            if (0 == matrix[0][col]) {
                for (int row = 0; row < matrix.Length; ++row) {
                    matrix[row][col] = 0;
                }
            }
        }
    }
    
    private void FillFirstRow(int[][] matrix, bool zeroInFirstRow) {
        if (zeroInFirstRow) {
            for (int col = 0; col < matrix[0].Length; ++col) {
                matrix[0][col] = 0;
            }
        }
    }
    
    private void FillFirstColumn(int[][] matrix, bool zeroInFirstCol) {
        if (zeroInFirstCol) {
            for (int row = 0; row < matrix.Length; ++row) {
                matrix[row][0] = 0;
            }
        }
    }
}