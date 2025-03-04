public class Vector2D {
    // The matrix to be traversed. Can be jagged
    private int[][] matrix;
    
    // Row index of the next element to return
    private int row = 0;
    
    // Column index of the next element to return
    private int col = 0;

    public Vector2D(int[][] matrix) {
        this.matrix = matrix;
        
        // Check if the first row contains no elements.
        // If so, search for the next row with a nonzero
        // amount of elements
        if (0 != this.matrix.Length && 0 == this.matrix[0].Length) {
            this.FindNextRow();
        }   
    }
    
    public int Next() {
        int value = this.matrix[row][col];
        
        // Move the column index to the right
        ++(this.col);
        
        // If the the column index has reached the end
        // of the current row, search for the next row
        // with a nonzero amount of elements and reset
        // the column index to zero
        if (this.matrix[this.row].Length == this.col) {
            this.FindNextRow();
            this.col = 0;
        }
        
        return value;
    }
    
    private void FindNextRow() {
        // Searches for the next row with a nonzero amount
        // of elements. Also, stops if it reaches the final row
        do {
            ++(this.row);
        } while (this.matrix.Length != this.row && 0 == this.matrix[this.row].Length);
    }
    
    public bool HasNext() => this.row < this.matrix.Length;
}

/**
 * Your Vector2D object will be instantiated and called as such:
 * Vector2D obj = new Vector2D(matrix);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */