public class Solution {
    public int[] KWeakestRows(int[][] mat, int numberOfWeakest) => mat
        .Select((int[] row, int index) => (row.Sum(), index)) // Since the matrix is a binary matrix and the amount of ones indicates the rows strength, the sum of a row will represent the strength of a row with a single number
        .OrderBy(((int strength, int index) val) => val.strength) // Sort based on previously computed strengths
        .Take(numberOfWeakest) // Take amount of entries needed
        .Select(((int strength, int index) val) => val.index) // Pull out the indices of the strongest rows
        .ToArray(); // Convert to array
}
