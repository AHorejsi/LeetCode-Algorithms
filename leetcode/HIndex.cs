public class Solution {
    private static readonly IComparer<int> comparer = Comparer<int>.Create((int left, int right) => right.CompareTo(left));
    
    public int HIndex(int[] citations) {
        Array.Sort(citations, Solution.comparer);
        int hIndex = 0;
        
        for (int index = 0; index < citations.Length; ++index) {
            int potentialHIndex = index + 1;
            
            if (citations[index] >= potentialHIndex) {
                hIndex = potentialHIndex;
            }
        }
        
        return hIndex;
    }
}