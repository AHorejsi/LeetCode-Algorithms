public class Solution {
    // Represents an empty space in the maze
    private const int Empty = 0;

    // Represents a wall in the maze
    private const int Wall = 1;

    public bool HasPath(int[][] maze, int[] start, int[] destination) {
        // Start position of the ball
        var startPos = new Position(start[0], start[1]);

        // Destination position of the ball
        var destinationPos = new Position(destination[0], destination[1]);

        // Tracks whether or not a given position has been arrived at previously. Meant to ensure
        // that a given position is not re-checked
        var visited = new HashSet<Position>();

        return this.MoveBall(maze, startPos, destinationPos, visited);
    }

    private bool MoveBall(int[][] maze, Position current, Position destination, HashSet<Position> visited) {
        if (visited.Contains(current)) {
            // If the given position have been visited before, then all of its diverging paths have already
            // been explored

            return false;
        }

        // Add the current position to the set of visited positions so that if it reached again,
        // it will not be re-checked
        visited.Add(current);

        var currentRowIndex = current.RowIndex;
        var currentColIndex = current.ColIndex;

        if (currentRowIndex == destination.RowIndex && currentColIndex == destination.ColIndex) {
            // If the current position is the destination position, then the answer has been obtained
            // and no more searching is necessary

            return true;
        }

        // Move the ball upwards. If upward movement is not possible, then do not
        // check this path
        var upRowIndex = this.MoveUp(maze, current);
        if (upRowIndex != currentRowIndex) {
            var newPos = new Position(upRowIndex, currentColIndex);

            if (this.MoveBall(maze, newPos, destination, visited)) {
                return true;
            }
        }

        // Move the ball downwards. If downward movement is not possible, then do not
        // check this path
        var downRowIndex = this.MoveDown(maze, current);
        if (downRowIndex != currentRowIndex) {
            var newPos = new Position(downRowIndex, currentColIndex);

            if (this.MoveBall(maze, newPos, destination, visited)) {
                return true;
            }
        }

        // Move the ball left. If leftward movement is not possible, then do not
        // check this path
        var leftColIndex = this.MoveLeft(maze, current);
        if (leftColIndex != currentColIndex) {
            var newPos = new Position(currentRowIndex, leftColIndex);

            if (this.MoveBall(maze, newPos, destination, visited)) {
                return true;
            }
        }

        // Move the ball right. If rightward is not possible, then do not
        // check this path
        var rightColIndex = this.MoveRight(maze, current);
        if (rightColIndex != currentColIndex) {
            var newPos = new Position(currentRowIndex, rightColIndex);

            if (this.MoveBall(maze, newPos, destination, visited)) {
                return true;
            }
        }

        // If all diverging paths from the current position fail to reach the destination, then we must
        // continue searching for the destination position
        return false;
    }

    private int MoveUp(int[][] maze, Position current) {
        var rowIndex = current.RowIndex;
        var colIndex = current.ColIndex;

        // Move the ball up until a wall or the bounds of the maze is hit
        while (0 != rowIndex && Solution.Empty == maze[rowIndex - 1][colIndex]) {
            --rowIndex;
        }

        return rowIndex;
    }

    private int MoveDown(int[][] maze, Position current) {
        var rowIndex = current.RowIndex;
        var colIndex = current.ColIndex;
        var endRowIndex = maze.Length - 1;

        // Move the ball down until a wall or the bounds of the maze is hit
        while (endRowIndex != rowIndex && Solution.Empty == maze[rowIndex + 1][colIndex]) {
            ++rowIndex;
        }

        return rowIndex;
    }

    private int MoveLeft(int[][] maze, Position current) {
        var rowIndex = current.RowIndex;
        var colIndex = current.ColIndex;

        // Move the ball left until a wall or the bounds of the maze is hit
        while (0 != colIndex && Solution.Empty == maze[rowIndex][colIndex - 1]) {
            --colIndex;
        }

        return colIndex;
    }

    private int MoveRight(int[][] maze, Position current) {
        var rowIndex = current.RowIndex;
        var colIndex = current.ColIndex;
        var endColIndex = maze[0].Length - 1;

        // Move the ball right until a wall or the bounds of the maze it hit
        while (endColIndex != colIndex && Solution.Empty == maze[rowIndex][colIndex + 1]) {
            ++colIndex;
        }

        return colIndex;
    }
}

// Represents a position in the maze
public struct Position {
    public readonly int RowIndex { get; }
    public readonly int ColIndex { get; }

    public Position(int rowIndex, int colIndex) {
        this.RowIndex = rowIndex;
        this.ColIndex = colIndex;
    }

    // Needed for use in "HashSet"
    public override bool Equals(object obj) {
        if (!(obj is Position)) {
            return false;
        }

        var pos = (Position)obj;

        return this.RowIndex == pos.RowIndex && this.ColIndex == pos.ColIndex;
    }

    // Needed for use in "HashSet"
    public override int GetHashCode() => HashCode.Combine(this.RowIndex, this.ColIndex);
}
