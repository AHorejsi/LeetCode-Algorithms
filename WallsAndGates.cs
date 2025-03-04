public class Solution {
    const int Wall = -1;
    const int Gate = 0;
    const int Empty = int.MaxValue;
    
    public void WallsAndGates(int[][] rooms) {
        Queue<(int, int)> spaces = this.FindGates(rooms);
        
        while (0 != spaces.Count) {
            (int rowIndex, int colIndex) = spaces.Dequeue();
            
            // Process all adjacent spaces
            this.ProcessSpace(rowIndex, colIndex, rowIndex - 1, colIndex, rooms, spaces);
            this.ProcessSpace(rowIndex, colIndex, rowIndex + 1, colIndex, rooms, spaces);
            this.ProcessSpace(rowIndex, colIndex, rowIndex, colIndex - 1, rooms, spaces);
            this.ProcessSpace(rowIndex, colIndex, rowIndex, colIndex + 1, rooms, spaces);
        }
    }
    
    // Initialize queue with positions of the gates
    private Queue<(int, int)> FindGates(int[][] rooms) {
        int rows = rooms.Length;
        int cols = rooms[0].Length;
        
        Queue<(int, int)> gates = new Queue<(int, int)>(rows * cols);
        
        for (int rowIndex = 0; rowIndex < rows; ++rowIndex) {
            for (int colIndex = 0; colIndex < cols; ++colIndex) {
                if (Gate == rooms[rowIndex][colIndex]) {
                    gates.Enqueue((rowIndex, colIndex));
                }
            }
        }
        
        return gates;
    }
    
    private void ProcessSpace(int currentRowIndex, int currentColIndex, int newRowIndex, int newColIndex, int[][] rooms, Queue<(int, int)> spaces) {
        // Do not process space if it is a wall, is non-empty, or is beyond the bounds of the matrix
        if (!(this.OutOfBounds(newRowIndex, newColIndex, rooms) || Wall == rooms[newRowIndex][newColIndex] || Empty != rooms[newRowIndex][newColIndex])) {
            // Assign the new space to the value of the current space increase by one
            rooms[newRowIndex][newColIndex] = rooms[currentRowIndex][currentColIndex] + 1;
            
            // Add the new space the queue so that spaces adjacent to the new space can
            // be processed as well
            spaces.Enqueue((newRowIndex, newColIndex));
        }
    }
    
    private bool OutOfBounds(int rowIndex, int colIndex, int[][] rooms) => rowIndex < 0 || rowIndex >= rooms.Length || colIndex < 0 || colIndex >= rooms[0].Length;
}