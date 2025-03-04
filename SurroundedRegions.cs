public class Solution {
    private const char Circle = 'O';
    private const char Cross = 'X';
    private const char Safe = '\u0000';

    public void Solve(char[][] board) {
        // Amount of rows on the board
        var rows = board.Length;

        // Amount of columns on the board
        var cols = board[0].Length;

        // Traverse the board and mark which values are safe
        this.Traverse(board, rows, cols);

        // Update the values on the board to their correct values
        this.Update(board, rows, cols);
    }

    // Traverse the board and mark any circles that are safe as such
    private void Traverse(char[][] board, int rows, int cols) {
        // Traverse top row for any circles and mark any circles connected to it as safe
        this.TraverseRow(board, cols, 0);

        // Traverse bottom row for any circles and mark any circles connected to it as safe
        this.TraverseRow(board, cols, rows - 1);
        
        // Traverse left column for any circles and mark any circles connected to it as safe
        this.TraverseColumn(board, rows, 0);

        // Traverse right column for any circles and mark any circles connected to it as safe
        this.TraverseColumn(board, rows, cols - 1);
    }

    // Traverse the specified row and look for circles. Mark them as safe as well as any circles connected to them
    private void TraverseRow(char[][] board, int cols, int rowIndex) {
        for (var colIndex = 0; colIndex < cols; ++colIndex) {
            if (Solution.Circle == board[rowIndex][colIndex]) {
                this.CheckFlip(board, rowIndex, colIndex);
            }
        }
    }

    // Traverse the specified column and look for circles. Mark them as safe as well as any circles connected to them
    private void TraverseColumn(char[][] board, int rows, int colIndex) {
        for (var rowIndex = 0; rowIndex < rows; ++rowIndex) {
            if (Solution.Circle == board[rowIndex][colIndex]) {
                this.CheckFlip(board, rowIndex, colIndex);
            }
        }
    }

    // Mark the given row and column indices as safe. Must be called initially on a position that
    // is on the border and is currently marked with a circle
    private void CheckFlip(char[][] board, int rowIndex, int colIndex) {
        // Mark the current position as safe for a circle
        board[rowIndex][colIndex] = Solution.Safe;

        // Check the position above for safeness
        this.CheckFlipHelper(board, rowIndex - 1, colIndex);

        // Check the position below for safeness
        this.CheckFlipHelper(board, rowIndex + 1, colIndex);

        // Check the position to the left for safeness
        this.CheckFlipHelper(board, rowIndex, colIndex - 1);

        // Check the position to the right for safeness
        this.CheckFlipHelper(board, rowIndex, colIndex + 1);
    }

    private void CheckFlipHelper(char[][] board, int rowIndex, int colIndex) {
        // Only keep traversing if the current position is in bounds
        if (!(rowIndex < 0 || rowIndex >= board.Length || colIndex < 0 || colIndex >= board[rowIndex].Length)) {

            // If the new position has a circle, flip it and continue traversing
            if (Solution.Circle == board[rowIndex][colIndex]) {
                this.CheckFlip(board, rowIndex, colIndex);
            }
        }
    }

    // Scan the board for positions marked as safe and set them to a circle.
    // Mark all other position with a cross
    private void Update(char[][] board, int rows, int cols) {
        for (var rowIndex = 0; rowIndex < rows; ++rowIndex) {
            for (var colIndex = 0; colIndex < cols; ++colIndex) {
                switch (board[rowIndex][colIndex]) {
                    // If the position still has a circle, it is surrounded and must be marked with a cross
                    case Solution.Circle:
                        board[rowIndex][colIndex] = Solution.Cross;

                        break;
                    // If the position has been previously marked as safe, it must be marked with a circle
                    case Solution.Safe:
                        board[rowIndex][colIndex] = Solution.Circle;

                        break;
                }
            }
        }
    }
}
