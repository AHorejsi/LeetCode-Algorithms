public class Solution {
    public int TotalNQueens(int dimensions) {
        SafetyTable safety = new SafetyTable(dimensions);
        int rowIndex = 0;
        
        return this.BuildTable(safety, rowIndex, dimensions);
    }
    
    private int BuildTable(SafetyTable safety, int rowIndex, int dimensions) {
        if (dimensions == rowIndex) {
            return 1;
        }
        
        int solvedCount = 0;
        int nextRowIndex = rowIndex + 1;

        for (int colIndex = 0; colIndex < dimensions; ++colIndex) {
            if (safety.IsSafe(rowIndex, colIndex)) {
                safety.ToggleSafety(rowIndex, colIndex);

                solvedCount += this.BuildTable(safety, nextRowIndex, dimensions);

                safety.ToggleSafety(rowIndex, colIndex);
            }
        }

        return solvedCount;
    }
    
    private sealed class SafetyTable {
        private int dimensions;
        private int diagCount;
        private int rowBitVector = -1;
        private int colBitVector = -1;
        private int majorDiagBitVector = -1;
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
