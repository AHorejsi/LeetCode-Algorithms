public class Solution {
    private struct Position {
        public int Row { get; }
        public int Column { get; }
        
        public Position(int row, int column) {
            this.Row = row;
            this.Column = column;
        }
    }
    
    private const int Empty = 0;
    private const int Fresh = 1;
    private const int Rotten = 2;
    
    public int OrangesRotting(int[][] grid) {
        (Queue<Position> rottingPositions, int freshCount) = this.FindInitialPositions(grid);
        
        int lastRowIndex = grid.Length - 1;
        int lastColIndex = grid[0].Length - 1;
        
        int minutesPassed = 0;
        
        while (0 != rottingPositions.Count) {
            int currentCount = rottingPositions.Count;
            bool change = false;
            
            for (int amount = 0; amount < currentCount; ++amount) {
                Position current = rottingPositions.Dequeue();
                
                int row = current.Row;
                int col = current.Column;
                
                if (0 != row) {
                    int prevRow = row - 1;
                    
                    if (Solution.Fresh == grid[prevRow][col]) {
                        rottingPositions.Enqueue(new Position(prevRow, col));
                        grid[prevRow][col] = Solution.Rotten;
                        
                        change = true;
                        --freshCount;
                    }
                }
                
                if (0 != col) {
                    int prevCol = col - 1;
                    
                    if (Solution.Fresh == grid[row][prevCol]) {
                        rottingPositions.Enqueue(new Position(row, prevCol));
                        grid[row][prevCol] = Solution.Rotten;
                        
                        change = true;
                        --freshCount;
                    }
                }
                
                if (lastRowIndex != row) {
                    int nextRow = row + 1;
                    
                    if (Solution.Fresh == grid[nextRow][col]) {
                        rottingPositions.Enqueue(new Position(nextRow, col));
                        grid[nextRow][col] = Solution.Rotten;
                        
                        change = true;
                        --freshCount;
                    }
                }
                
                if (lastColIndex != col) {
                    int nextCol = col + 1;
                    
                    if (Solution.Fresh == grid[row][nextCol]) {
                        rottingPositions.Enqueue(new Position(row, nextCol));
                        grid[row][nextCol] = Solution.Rotten;
                        
                        change = true;
                        --freshCount;
                    }
                }
            }
            
            if (change) {
                ++minutesPassed;
            }
            else {
                break;
            }
        }
        
        return 0 == freshCount ? minutesPassed : -1;
    }
    
    private (Queue<Position>, int) FindInitialPositions(int[][] grid) {
        Queue<Position> positions = new Queue<Position>(grid.Length * grid[0].Length);
        int freshCount = 0;
        
        for (int rowIndex = 0; rowIndex < grid.Length; ++rowIndex) {
            for (int colIndex = 0; colIndex < grid[rowIndex].Length; ++colIndex) {
                switch (grid[rowIndex][colIndex]) {
                case Solution.Fresh:
                    ++freshCount;
                    break;
                case Solution.Rotten:
                    positions.Enqueue(new Position(rowIndex, colIndex));
                    break;
                }
            }
        }
        
        return (positions, freshCount);
    }
}