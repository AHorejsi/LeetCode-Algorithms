public class Solution {
    private enum MoveMode { Up, Down, Left, Right };
    
    public IList<int> SpiralOrder(int[][] matrix) {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int size = rows * cols;
        
        List<int> output = new List<int>(size);
        int[] lastFilled = { 0, rows, -1, cols };
        MoveMode mode = MoveMode.Right;
        int rowIndex = 0;
        int colIndex = 0;
        
        while (output.Count != size) {
            output.Add(matrix[rowIndex][colIndex]);
            (mode, rowIndex, colIndex) = this.DetermineNextMove(lastFilled, mode, rowIndex, colIndex);
        }
        
        return output;
    }
    
    private (MoveMode, int, int) DetermineNextMove(int[] lastFilled, MoveMode mode, int rowIndex, int colIndex) {
        int modeAsIndex = (int)mode;
        
        switch (mode) {
        case MoveMode.Up:
            if (rowIndex - 1 == lastFilled[modeAsIndex]) {
                mode = MoveMode.Right;
                ++colIndex;
                
                lastFilled[modeAsIndex] = rowIndex;
            }
            else {
                --rowIndex;
            }

            break;
        case MoveMode.Down:
            if (rowIndex + 1 == lastFilled[modeAsIndex]) {
                mode = MoveMode.Left;
                --colIndex;
                
                lastFilled[modeAsIndex] = rowIndex;
            }
            else {
                ++rowIndex;
            }

            break;
        case MoveMode.Left:
            if (colIndex - 1 == lastFilled[modeAsIndex]) {
                mode = MoveMode.Up;
                --rowIndex;
                
                lastFilled[modeAsIndex] = colIndex;
            }
            else {
                --colIndex;
            }

            break;
        case MoveMode.Right:
            if (colIndex + 1 == lastFilled[modeAsIndex]) {
                mode = MoveMode.Down;
                ++rowIndex;
                
                lastFilled[modeAsIndex] = colIndex;
            }
            else {
                ++colIndex;
            }

            break;
        }
        
        return (mode, rowIndex, colIndex);
    }
}