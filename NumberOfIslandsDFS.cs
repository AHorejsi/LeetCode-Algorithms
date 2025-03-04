public class Solution {
    private const char Land = '1';
    private const char Water = '0';
    
    public int NumIslands(char[][] grid) {
        // The number of rows in "grid"
        int rows = grid.Length;
        
        // The number of columns in "grid"
        int cols = grid[0].Length;
        
        // Marks which positions in "grid" that have been visited
        bool[,] visited = new bool[rows, cols];
        
        // The current number of islands in "grid" that have been found
        int islandCount = 0;
        
        // Counts the number of islands in "grid"
        for (int rowIndex = 0; rowIndex < rows; ++rowIndex) {
            for (int colIndex = 0; colIndex < cols; ++colIndex) {
                // Indicates whether or not the space corresponding to "rowIndex"
                // and "colIndex" was the start of a new island. Not open
                // water or a previously found island
                bool islandFound = this.TraverseIsland(grid, visited, rowIndex, colIndex);

                if (islandFound) {
                    ++islandCount;
                }
            }
        }
        
        return islandCount;
    }
    
    // Visits the current space, then searches adjacent positions through a depth-first search. Expands outward and only
    // stops when water is reached or an already visited space is encountered. Returns whether
    // or "true" when new land was found, "false" otherwise
    private bool TraverseIsland(char[][] grid, bool[,] visited, int rowIndex, int colIndex) {
        if (
			grid.Length == rowIndex || -1 == rowIndex ||
            grid[0].Length == colIndex || -1 == colIndex ||
            visited[rowIndex, colIndex]
        ) {
            // If the "rowIndex" or "colIndex" is out of bounds, then we are currently pointing at open water.
            // If the given position corresponding to "rowIndex" and "colIndex" has already been visited, then
            // there is no need to search again
            return false;
        }
        else {
            // Indicates whether or not the current space points to land that
            // was not previously visited
            bool newLand;
            
            if (Land == grid[rowIndex][colIndex] && !visited[rowIndex, colIndex]) {
                // If the current space is land and has not been visited before,
                // mark as visited, explore adjacent spaces
                
                visited[rowIndex, colIndex] = true;
                newLand = true;
                
                this.TraverseIsland(grid, visited, rowIndex + 1, colIndex);
                this.TraverseIsland(grid, visited, rowIndex, colIndex + 1);
                this.TraverseIsland(grid, visited, rowIndex - 1, colIndex);
                this.TraverseIsland(grid, visited, rowIndex, colIndex - 1);
            }
            else {
                // If the current space is land or has been visited,
                // mark as not new land
                newLand = false;
            }
            
            return newLand;
        }
    }
}
