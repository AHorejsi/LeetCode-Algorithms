public class Solution {
    public bool IsValidSudoku(char[][] board) {
        const int dimensions = 9;
        const int boxDimensions = 3;
        
        int[] rowBitVectors = new int[dimensions];
        int[] columnBitVectors = new int[dimensions];
        int[] boxBitVectors = new int[dimensions];
        
        for (int i = 0; i < dimensions; ++i) {
            for (int j = 0; j < dimensions; ++j) {
                char current = board[i][j];
                
                if ('.' != current) {
                    int charNumber = current - '0';
                    int mask = 1 << charNumber;
                    
                    if (0 == (rowBitVectors[i] & mask)) {
                        rowBitVectors[i] |= mask;
                    }
                    else {
                        return false;
                    }
                    
                    if (0 == (columnBitVectors[j] & mask)) {
                        columnBitVectors[j] |= mask;
                    }
                    else {
                        return false;
                    }
                    
                    int boxBitVectorIndex = (i / boxDimensions) * boxDimensions + j / boxDimensions;
                    
                    if (0 == (boxBitVectors[boxBitVectorIndex] & mask)) {
                        boxBitVectors[boxBitVectorIndex] |= mask;
                    }
                    else {
                        return false;
                    }
                }
            }
        }
        
        return true;
    }
}