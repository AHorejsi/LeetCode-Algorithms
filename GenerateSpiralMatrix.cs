public class Solution {
    private enum MoveMode { Up, Down, Left, Right }
    
    public int[][] GenerateMatrix(int dimensions) {
        int[][] matrix = this.MakeMatrix(dimensions);
        int[] lastFilled = { 0, dimensions, -1, dimensions };
        
        int rowIndex = 0;
        int colIndex = 0;
        MoveMode mode = MoveMode.Right;
        int size = dimensions * dimensions;
        
        for (int val = 1; val <= size; ++val) {
            matrix[rowIndex][colIndex] = val;
            int modeAsIndex = (int)mode;
            
            switch (mode) {
            case MoveMode.Up:
                if (rowIndex - 1 != lastFilled[modeAsIndex]) {
                    --rowIndex;
                }
                else {
                    mode = MoveMode.Right;
                    ++colIndex;

                    lastFilled[modeAsIndex] = rowIndex;
                }
                    
                break;
            case MoveMode.Down:
                if (rowIndex + 1 != lastFilled[modeAsIndex]) {
                    ++rowIndex;
                }
                else {
                    mode = MoveMode.Left;
                    --colIndex;

                    lastFilled[modeAsIndex] = rowIndex;
                }    
                
                break;
            case MoveMode.Left:
                if (colIndex - 1 != lastFilled[modeAsIndex]) {
                    --colIndex;
                }
                else {
                    mode = MoveMode.Up;
                    --rowIndex;

                    lastFilled[modeAsIndex] = colIndex;
                }
                
                break;
            case MoveMode.Right:
                if (colIndex + 1 != lastFilled[modeAsIndex]) {
                    ++colIndex;
                }
                else {
                    mode = MoveMode.Down;
                    ++rowIndex;

                    lastFilled[modeAsIndex] = colIndex;
                }
                    
                break;
            }
        }
        
        return matrix;
    }
    
    private int[][] MakeMatrix(int dimensions) {
        int[][] matrix = new int[dimensions][];
        
        for (int index = 0; index < matrix.Length; ++index) {
            matrix[index] = new int[dimensions];
        }
        
        return matrix;
    }
}