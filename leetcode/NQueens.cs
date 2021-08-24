public class Solution {
    private const char Empty = '.';
    private const char Filled = 'Q';
    
    public IList<IList<string>> SolveNQueens(int dimensions) {
        IList<IList<string>> solutions = new List<IList<string>>();
        IList<StringBuilder> board = this.MakeInitialBoardState(dimensions);
        
        this.Solve(board, 0, solutions);
        
        return solutions;
    }
    
    private IList<StringBuilder> MakeInitialBoardState(int dimensions) {
        IList<StringBuilder> board = new List<StringBuilder>(dimensions);
        
        for (int count = 0; count < dimensions; ++count) {
            StringBuilder sb = new StringBuilder(dimensions);
            
            for (int index = 0; index < dimensions; ++index) {
                sb.Append(Solution.Empty);
            }
            
            board.Add(sb);
        }
        
        return board;
    }
    
    private void Solve(IList<StringBuilder> board, int row, IList<IList<string>> solutions) {
        if (board.Count == row) {
            IList<string> result = board.Select((StringBuilder sb) => sb.ToString()).ToList();
            solutions.Add(result);
        }
        else {
            for (int col = 0; col < board.Count; ++col) {
                if (this.Safe(board, row, col)) {
                    board[row][col] = Solution.Filled;
                    this.Solve(board, row + 1, solutions);
                    board[row][col] = Solution.Empty;
                }
            }
        }
    }
    
    private bool Safe(IList<StringBuilder> board, int row, int col) => this.RowSafe(board, row) && this.ColSafe(board, col) && this.MajorDiagonalSafe(board, row, col) && this.MinorDiagonalSafe(board, row, col);
    
    private bool RowSafe(IList<StringBuilder> board, int row) {
        for (int col = 0; col < board.Count; ++col) {
            if (Solution.Filled == board[row][col]) {
                return false;
            }
        }
        
        return true;
    }
    
    private bool ColSafe(IList<StringBuilder> board, int col) {
        for (int row = 0; row < board.Count; ++row) {
            if (Solution.Filled == board[row][col]) {
                return false;
            }
        }
        
        return true;
    }
    
    private bool MajorDiagonalSafe(IList<StringBuilder> board, int row, int col) {
        int checkRow = row + 1;
        int checkCol = col + 1;
        
        while (checkRow < board.Count && checkCol < board.Count) {
            if (Solution.Filled == board[checkRow][checkCol]) {
                return false;
            }
            
            ++checkRow;
            ++checkCol;
        }
        
        checkRow = row - 1;
        checkCol = col - 1;
        
        while (checkRow >= 0 && checkCol >= 0) {
            if (Solution.Filled == board[checkRow][checkCol]) {
                return false;
            }
            
            --checkRow;
            --checkCol;
        }
        
        return true;
    }
    
    private bool MinorDiagonalSafe(IList<StringBuilder> board, int row, int col) {
        int checkRow = row + 1;
        int checkCol = col - 1;
        
        while (checkRow < board.Count && checkCol >= 0) {
            if (Solution.Filled == board[checkRow][checkCol]) {
                return false;
            }
            
            ++checkRow;
            --checkCol;
        }
        
        checkRow = row - 1;
        checkCol = col + 1;
        
        while (checkRow >= 0 && checkCol < board.Count) {
            if (Solution.Filled == board[checkRow][checkCol]) {
                return false;
            }
            
            --checkRow;
            ++checkCol;
        }
        
        return true;
    }
}