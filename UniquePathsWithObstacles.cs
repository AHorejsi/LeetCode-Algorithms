public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int[,] paths = new int[obstacleGrid.Length, obstacleGrid[0].Length];
        
        this.SetInitialRowAndColumn(paths, obstacleGrid);
        this.SetRestOfPositions(paths, obstacleGrid);
        
        return paths[paths.GetLength(0) - 1, paths.GetLength(1) - 1];
    }
    
    private void SetInitialRowAndColumn(int[,] paths, int[][] obstacleGrid) {
        bool obstacleFoundInRow = false;
        
        for (int i = 0; i < paths.GetLength(0); ++i) {
            if (!obstacleFoundInRow) {
                obstacleFoundInRow = (1 == obstacleGrid[i][0]);
            }
            
            paths[i, 0] = obstacleFoundInRow ? 0 : 1;
        }
        
        bool obstacleFoundInCol = false;
        
        for (int j = 0; j < paths.GetLength(1); ++j) {
            if (!obstacleFoundInCol) {
                obstacleFoundInCol = (1 == obstacleGrid[0][j]);
            }
            
            paths[0, j] = obstacleFoundInCol ? 0 : 1;
        }
    }
    
    private void SetRestOfPositions(int[,] paths, int[][] obstacleGrid) {
        int rows = paths.GetLength(0);
        int cols = paths.GetLength(1);
        
        for (int i = 1; i < rows; ++i) {
            for (int j = 1; j < cols; ++j) {
                if (1 == obstacleGrid[i][j]) {
                    paths[i, j] = 0;
                }
                else {
                    paths[i, j] = paths[i - 1, j] + paths[i, j - 1];
                }
            }
        }
    }
}