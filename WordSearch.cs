public class Solution {    
    public bool Exist(char[][] board, string word) {
        for (int i = 0; i < board.Length; ++i) {
            for (int j = 0; j < board[i].Length; ++j) {
                if (board[i][j] == word[0] && this.Search(1, board, word, i, j, new HashSet<(int, int)>())) {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private bool Search(int indexOfWord, char[][] board, string word, int row, int col, HashSet<(int, int)> used) {        
        if (word.Length == indexOfWord) {
            return true;
        }
        else {
            (int, int) up = (row - 1, col);
            (int, int) left = (row, col - 1);
            (int, int) down = (row + 1, col);
            (int, int) right = (row, col + 1);
            (int, int) current = (row, col);
        
            used.Add(current);
            
            if (0 != row && !used.Contains(up) && word[indexOfWord] == board[row - 1][col]) {
                if (this.Search(indexOfWord + 1, board, word, row - 1, col, used)) {
                    return true;
                }
            }
            
            if (0 != col && !used.Contains(left) && word[indexOfWord] == board[row][col - 1]) {
                if (this.Search(indexOfWord + 1, board, word, row, col - 1, used)) {
                    return true;
                }
            }
            
            if (board.Length - 1 != row && !used.Contains(down) && word[indexOfWord] == board[row + 1][col]) {
                if (this.Search(indexOfWord + 1, board, word, row + 1, col, used)) {
                    return true;
                }
            }
            
            if (board[0].Length - 1 != col && !used.Contains(right) && word[indexOfWord] == board[row][col + 1]) {
                if (this.Search(indexOfWord + 1, board, word, row, col + 1, used)) {
                    return true;
                }
            }
            
            used.Remove(current);
            
            return false;
        }
    }
}