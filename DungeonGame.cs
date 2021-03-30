public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) {
        int rows = dungeon.Length;
        int cols = dungeon[0].Length;
        int[,] hp = new int[rows, cols];
        
        for (int i = rows - 1; i >= 0; --i) {
            for (int j = cols - 1; j >= 0; --j) {
                hp[i, j] = this.CalcHp(hp, dungeon, i, j, rows, cols);
            }
        }
        
        return hp[0, 0];
    }
    
    private int CalcHp(int[,] hp, int[][] dungeon, int i, int j, int rows, int cols) {
        int downIndex = i + 1;
        int rightIndex = j + 1;
        
        int downValue;
        int rightValue;
        int currentValue = dungeon[i][j];
        
        if (downIndex == rows && rightIndex == cols) {
            return (currentValue >= 0) ? 1 : -currentValue + 1;
        }
        else if (downIndex == rows) {
            downValue = int.MaxValue;
            rightValue = hp[i, rightIndex];
        }
        else if (rightIndex == cols) {
            downValue = hp[downIndex, j];
            rightValue = int.MaxValue;
        }
        else {
            downValue = hp[downIndex, j];
            rightValue = hp[i, rightIndex];
        }
        
        int downHp = 1;
        int rightHp = 1;
        
        if (downValue > currentValue) {
            downHp = downValue - currentValue;
        }
        
        if (rightValue > currentValue) {
            rightHp = rightValue - currentValue;
        }
        
        if (int.MaxValue == downValue) {
            return rightHp;
        }
        else if (int.MaxValue == rightValue) {
            return downHp;
        }
        else {
            return Math.Min(downHp, rightHp);
        }
    }
}