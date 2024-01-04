public class Solution {
    private const char Land = '1';
    private const char Water = '0';
    
    // Refers to the state of each value in "grid." "Unseen" means
    // that the given position has not been visited and is not waiting
    // the queue. "Waiting" means it is sitting in the queue waiting to
    // be visited. "Visited" means the position has been examined and processed
    private enum PositionState { Unseen, Waiting, Visited }
    
    public int NumIslands(char[][] grid) {
        // The number of rows in "grid"
        int rows = grid.Length;
        
        // The number of columns in "grid"
        int cols = grid[0].Length;
        
        // The state of each position during breadth-first traversal
        PositionState[,] states = new PositionState[rows, cols];
        
        // The queue to be used for a breadth-first traversal
        Queue<(int, int)> queue = new Queue<(int, int)>(rows * cols);
        
        // The amount of islands that have been currently found
        int islandCount = 0;
        
        // Count the number of islands in "grid"
        for (int rowIndex = 0; rowIndex < rows; ++rowIndex) {
            for (int colIndex = 0; colIndex < cols; ++colIndex) {
                // Try adding the current position specified by "rowIndex"
                // and "colIndex" to the queue
                this.TryAddToQueue(queue, grid, states, rowIndex, colIndex);
                
                // Only enter this if block in the event that the previous attempt
                // to add the current position to the queue was successful
                if (0 != queue.Count) {
                    // Traverse the island and mark those positions as "Visited"
                    this.TraverseIsland(queue, grid, states);
                    
                    // Count the current island
                    ++islandCount;
                }
            }
        }
        
        return islandCount;
    }
    
    private void TraverseIsland(Queue<(int, int)> queue, char[][] grid, PositionState[,] states) {
        do {
            // Get the current position
            (int rowIndex, int colIndex) = queue.Dequeue();
            
            // Mark the current position as visited
            states[rowIndex, colIndex] = PositionState.Visited;
            
            // Add all adjacent positions to the queue
            this.TryAddToQueue(queue, grid, states, rowIndex + 1, colIndex);
            this.TryAddToQueue(queue, grid, states, rowIndex - 1, colIndex);
            this.TryAddToQueue(queue, grid, states, rowIndex, colIndex + 1);
            this.TryAddToQueue(queue, grid, states, rowIndex, colIndex - 1);
        } while (0 != queue.Count);
    }
    
    private void TryAddToQueue(Queue<(int, int)> queue, char[][] grid, PositionState[,] states, int rowIndex, int colIndex) {
        // Adds "rowIndex" and "colIndex" to "queue" if the corresponding position has "Unseen" status and is land
        if (
            rowIndex >= 0 && rowIndex < states.GetLength(0) &&
            colIndex >= 0 && colIndex < states.GetLength(1) &&
            Land == grid[rowIndex][colIndex] && PositionState.Unseen == states[rowIndex, colIndex]
        ) {
            // Add the position to the queue for later traversal
            queue.Enqueue((rowIndex, colIndex));
            
            // Mark the position as present in the queue and waiting for examination
            states[rowIndex, colIndex] = PositionState.Waiting;
        }
    }
}