public class Solution {
    public bool CheckValid(int[][] matrix) {
        // Each row corresponds to the row in "matrix" with the same index
        // Each column corresponds the value from 1 to "matrix.Length". With
        // column index 0 corresponding to value 1, column index 1 corresponding to value 2, etc.
        bool[,] rows = new bool[matrix.Length, matrix.Length];
        
        // Each column corresponds the column in "matrix" with the same index
        // Each row corresponds the value from 1 to "matrix.Length". With
        // row index 0 corresponding to value 1, row index 1 corresponding to value 2, etc.
        bool[,] cols = new bool[matrix.Length, matrix.Length];
        
        // Indicates a value beyond 1 to "matrix.Length" was not found during traversal.
        // If a value beyond 1 to "matrix.Length" was found, the below, return statement
        // will return false
        bool inBounds = this.TraverseMatrix(matrix, rows, cols);
        
        return inBounds && this.AllTrue(rows, cols);
    }
    
    private bool TraverseMatrix(int[][] matrix, bool[,] rows, bool[,] cols) {
        int length = matrix.Length;
        
        // In accordance with the definitions for "rows" and "cols" described above,
        // sets the values in those matrices to true to indicate that the value in question
        // is present in the given row specified by "rows" and the given column specified
        // by "cols". If "matrix" contains 1 to "matrix.Length" in all rows and columns,
        // then the entriety of both "rows" and "cols" will be set to true
        for (int rowIndex = 0; rowIndex < length; ++rowIndex) {
            for (int colIndex = 0; colIndex < matrix.Length; ++colIndex) {
                // Value is represented by its index in the matrix subtracted by one
                int index = matrix[rowIndex][colIndex] - 1;
                
                if (index < 0 || index >= length) {
                    // Value beyond the specified range has been found,
                    // therefore every row and column does not contain all
                    // elements from 1 to "matrix.Length"
                    return false;
                }
                
                // "rowIndex" corresponds to the same row index of "matrix"
                // "index" corresponds to the value currently being processed
                // that is between 1 to "matrix.Length"
                rows[rowIndex, index] = true;
                
                // "colIndex" corresponds to the same column index of "matrix"
                // "index" corresponds to the value currently being processed
                // that is between 1 to "matrix.Length"
                cols[index, colIndex] = true;
            }
        }
        
        return true;
    }
    
    private bool AllTrue(bool[,] rows, bool[,] cols) {
        int rowCount = rows.GetLength(0);
        int colCount = rows.GetLength(1);
        
        // Check if all values in both "rows" and "cols" are set to true
        for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex) {
            for (int colIndex = 0; colIndex < colCount; ++colIndex) {
                if (!(rows[rowIndex, colIndex] && cols[rowIndex, colIndex])) {
                    return false;
                }
            }
        }
        
        return true;
    }
}