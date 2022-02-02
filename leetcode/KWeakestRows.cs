public class Solution {
    public int[] KWeakestRows(int[][] mat, int numberOfWeakest) => mat
        .Select((int[] row, int index) => (row.Sum(), index, row))
        .OrderBy(((int strength, int index, int[] row) val) => val.strength)
        .Take(numberOfWeakest)
        .Select(((int strength, int index, int[] row) val) => val.index)
        .ToArray();
}