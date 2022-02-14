public class Solution {
    public int[] KWeakestRows(int[][] mat, int numberOfWeakest) => mat
        .Select((int[] row, int index) => (row.Sum(), index))
        .OrderBy(((int strength, int index) val) => val.strength)
        .Take(numberOfWeakest)
        .Select(((int strength, int index) val) => val.index)
        .ToArray();
}
