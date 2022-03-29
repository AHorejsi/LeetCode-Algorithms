public class Solution {
    public int TotalNQueens(int dimensions) => this.BuildTable(, 0, dimensions);
    
    private int BuildTable(SafetyTable safety, int rowIndex, int dimensions) {
        if (dimensions == rowIndex) {
            // If the current row index is equal to the dimensions of the chess board,
            // then a solution has been found and there is only one solution corresponding
            // to the current board state
            
            return 1;
        }
        
        // Tracks the number of solutions found during any recursive calls
        int solvedCount = 0;
        
        // The index of the following row
        int nextRowIndex = rowIndex + 1;
        
        // Traverse the columns of the current row for safe spaces
        for (int colIndex = 0; colIndex < dimensions; ++colIndex) {
            if (safety.IsSafe(rowIndex, colIndex)) {
                // If the position corresponding to "rowIndex" and "colIndex" is safe,
                // a queen can be placed there
                
                // Toggle safety of the current space. Since the board was initialized
                // to all spaces being safe, this call will only set the current space to unsafe
                safety.ToggleSafety(rowIndex, colIndex);
                
                // Add any solutions found in the foloowing recursive call to the total count
                solvedCount += this.BuildTable(safety, nextRowIndex, dimensions);
                
                // Toggle the safety of the current space. Since the given space was 
                // set to unsafe previously, this will set it to safe
                safety.ToggleSafety(rowIndex, colIndex);
            }
        }

        return solvedCount;
    }
    
    // Tracks which positions are attackable by another, current placed queen.
    // All spaces are initialized to being safe (not attackable)
    private sealed class SafetyTable {
        // The dimensions of the chess board
        private int dimensions;
        
        // The number of sequences of diagonally adjacent spaces
        private int diagCount;
        
        // Bit flags that track which rows are safe
        private int rowBitVector = -1;
        
        // Bit flags that track which columns are safe
        private int colBitVector = -1;
        
        // Bit flags that track which major diagonals are safe
        private int majorDiagBitVector = -1;
        
        // Bit flags that track which minor diagonals are safe
        private int minorDiagBitVector = -1;
        
        public SafetyTable(int dimensions) {
            this.dimensions = dimensions;
            this.diagCount = 2 * dimensions - 1;
        }
        
        public void ToggleSafety(int rowIndex, int colIndex) {
            int majorDiagIndex = this.MajorDiagIndex(rowIndex, colIndex);
            int minorDiagIndex = this.MinorDiagIndex(rowIndex, colIndex);
            
            this.rowBitVector ^= 1 << rowIndex;
            this.colBitVector ^= 1 << colIndex;
            this.majorDiagBitVector ^= 1 << majorDiagIndex;
            this.minorDiagBitVector ^= 1 << minorDiagIndex;
        }
        
        public bool IsSafe(int rowIndex, int colIndex) {
            int majorDiagIndex = this.MajorDiagIndex(rowIndex, colIndex);
            int minorDiagIndex = this.MinorDiagIndex(rowIndex, colIndex);
            
            return
                0 != (this.rowBitVector >> rowIndex & 1) &&
                0 != (this.colBitVector >> colIndex & 1) &&
                0 != (this.majorDiagBitVector >> majorDiagIndex & 1) &&
                0 != (this.minorDiagBitVector >> minorDiagIndex & 1);
        }
        
        private int MajorDiagIndex(int rowIndex, int colIndex) => this.dimensions - (rowIndex - colIndex) - 1;
        
        private int MinorDiagIndex(int rowIndex, int colIndex) => this.diagCount - (rowIndex + colIndex) - 1;
    }
}
