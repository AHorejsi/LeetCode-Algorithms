public class Solution {
    public int[][] Merge(int[][] intervals) {
        List<int[]> result = new List<int[]>(intervals.Length);
        
        Array.Sort(intervals, (arr1, arr2) => arr1[0] - arr2[0]);
        
        foreach (int[] interval in intervals) {
            if (0 == result.Count || result[result.Count - 1][1] < interval[0]) {
                result.Add(interval);
            }
            else {
                result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], interval[1]);
            }
        }
        
        return result.ToArray();
    }
}