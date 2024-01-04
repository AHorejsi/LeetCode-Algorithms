public class Solution {
    public double ChampagneTower(int amountToPour, int rowIndex, int glassIndex) {
        // Construct a tower of empty glasses
        var tower = this.ConstructTower(rowIndex + 1);

        // Fill the tower of glasses with liquid
        this.FillTower(tower, amountToPour);

        // Return the amount filled in the queried glass
        return tower[rowIndex][glassIndex];
    }

    private List<List<double>> ConstructTower(int rows) {
        // The tower will be represented with a list of lists where
        // each list represents a row of the tower and each list contains
        // one more double value than the previous list. Only allocate
        // the number of glasses necessary to include the queried glass.
        // No rows past the row of the queried glass need to be represented
        // because if the queried glass ends up full, its state cannot change further
        var tower = new List<List<double>>(rows);

        for (var rowIndex = 0; rowIndex < rows; ++rowIndex) {
            // Make each glass empty by initializing it with a value of zero
            var row = Enumerable.Repeat(0.0, rowIndex + 1).ToList();

            // Add the new row to the tower
            tower.Add(row);
        }

        return tower;
    }

    private void FillTower(List<List<double>> tower, int amountToPour) {
        // Used to do a breadth-first search of the tower.
        // Breadth-first search is necessary for the tower
        // to be filled out correctly because a given glass
        // can be filled by more than one glass from the previous row
        var traversal = new Queue<Position>();
        
        // Initialize the topmost glass as having every
        // cup of liquid
        traversal.Enqueue(new Position(0, 0));
        tower[0][0] = amountToPour;

        while (0 != traversal.Count) {
            // The position of the current glass to fill
            var current = traversal.Dequeue();

            // The row index of the current glass to fill
            var rowIndex = current.RowIndex;

            // The glass index of the current glass to fill
            var glassIndex = current.GlassIndex;

            // Represents the amount of liquid that will pour into
            // child glasses in the tower. This can cause the child
            // glasses to overflow which can then cascade to further
            // child glasses
            var takeaway = tower[rowIndex][glassIndex] - 1.0;

            // If there is no liquid to take away from the current glass,
            // then there is no need to account for its child glasses
            if (takeaway > 0) {
                // Reset the current glass to 1 so that its value
                // be set correctly
                tower[rowIndex][glassIndex] = 1.0;
                
                // The row index of the child glasses
                var nextRowIndex = rowIndex + 1;

                // The glass index of the right child glass
                var nextGlassIndex = glassIndex + 1;

                // If the following row index is beyond the bounds of the tower
                // then it does not need to have its value tracked
                if (nextRowIndex < tower.Count) {
                    // The amount of liquid overflowing from the current glass.
                    // This will be put into successive glasses. The overflow
                    // is always split evenly between the two child glasses
                    var overflow = takeaway / 2.0;

                    // Add liquid to the left child glass
                    tower[nextRowIndex][glassIndex] += overflow;

                    // Add liquid to the right child glass
                    tower[nextRowIndex][nextGlassIndex] += overflow;

                    // Add the child glasses to the queue
                    traversal.Enqueue(new Position(nextRowIndex, glassIndex));
                    traversal.Enqueue(new Position(nextRowIndex, nextGlassIndex));
                }
            }
        }
    }
}

public struct Position {
    // Corresponds to a row index of the tower
    public int RowIndex { get; }

    // Corresponds to a glass index of the tower
    public int GlassIndex { get; }

    public Position(int rowIndex, int glassIndex) {
        this.RowIndex = rowIndex;
        this.GlassIndex = glassIndex;
    }
}
