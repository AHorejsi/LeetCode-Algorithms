public class Solution {
    // Entry point
    public int MinimumTotal(IList<IList<int>> triangle) => this.MinimumTotalHelper(triangle, new Position(0, 0), new Dictionary<Position, int>());

    // triangle - The triangle whose minimum path sum is to be computed
    // pos - The position of the current node to have its minimum path sum computed
    // seen - Memoization of subtrees that have had their minimum path sums already computed
    private int MinimumTotalHelper(IList<IList<int>> triangle, Position pos, Dictionary<Position, int> seen) {
        if (triangle.Count == pos.RowIndex) {
            // If the row index of the current position is past the end of the triangle, then there are no more
            // numbers to count for this path. Zero will not contribute to the sum

            return 0;
        }
        else if (seen.ContainsKey(pos)) {
            // If the minimum path sum of a given subtree has already been computed, then reuse the solution

            return seen[pos];
        }
        else {
            var rowIndex = pos.RowIndex;
            var colIndex = pos.ColIndex;

            // The row index of the child nodes of the current position
            var nextRowIndex = rowIndex + 1;
            // The column index of the right child node of the current position
            var nextColIndex = colIndex + 1;

            // The positions of the child nodes of the current position
            var leftPos = new Position(nextRowIndex, colIndex);
            var rightPos = new Position(nextRowIndex, nextColIndex);

            // The minimum path sum of both left and right subtrees
            var leftSum = this.MinimumTotalHelper(triangle, leftPos, seen);
            var rightSum = this.MinimumTotalHelper(triangle, rightPos, seen);

            // The minimum path sum of the cyrrebt subtree
            var minSum = triangle[rowIndex][colIndex] + Math.Min(leftSum, rightSum);

            // Add the minimum path sum of the current position so that memoization will work
            seen.Add(pos, minSum);

            return minSum;
        }
    }
}

public struct Position : IEquatable<Position> {
    public int RowIndex { get; }
    public int ColIndex { get; }

    public Position(int rowIndex, int colIndex) {
        this.RowIndex = rowIndex;
        this.ColIndex = colIndex;
    }

    public override bool Equals(object obj) => obj is Position && this.Equals((Position)obj);

    public bool Equals(Position other) => this.RowIndex == other.RowIndex && this.ColIndex == other.ColIndex;

    public override int GetHashCode() => HashCode.Combine(this.RowIndex, this.ColIndex);
}
