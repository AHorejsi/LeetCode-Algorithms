public class Solution {
    private const char BLACK = 'B';
    private const char WHITE = 'W';

    public int FindLonelyPixel(char[][] picture) {
        // Represents the number of lonely, black pixels
        var lonelyBlackCount = 0;

        for (var rowIndex = 0; rowIndex < picture.Length; ++rowIndex) {
            for (var colIndex = 0; colIndex < picture[rowIndex].Length; ++colIndex) {
                if (Solution.BLACK == picture[rowIndex][colIndex] && this.IsLonely(picture, rowIndex, colIndex)) {
                    ++lonelyBlackCount;
                }
            }
        }

        return lonelyBlackCount;
    }

    private bool IsLonely(char[][] picture, int rowIndex, int colIndex) {
        // Check if the black pixel at "rowIndex" and "colIndex" has no other black pixels in its row
        for (var rowIndex2 = 0; rowIndex2 < picture.Length; ++rowIndex2) {
            if (rowIndex != rowIndex2 && Solution.BLACK == picture[rowIndex2][colIndex]) {
                return false;
            }
        }

        // Check if the black pixel at "rowIndex" and "colIndex" has no other black pixels in its column
        for (var colIndex2 = 0; colIndex2 < picture[0].Length; ++colIndex2) {
            if (colIndex != colIndex2 && Solution.BLACK == picture[rowIndex][colIndex2]) {
                return false;
            }
        }

        return true;
    }
}
