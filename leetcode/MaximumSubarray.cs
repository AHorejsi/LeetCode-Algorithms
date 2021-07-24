public class Solution {
    public int MaxSubArray(int[] nums) {
        if (0 == nums.Length) {
            throw new ArgumentException("Empty array");
        }
        
        int current = nums.First();
        int max = nums.First();

        foreach (int val in nums.Skip(1)) {
            current = Math.Max(val, current + val);
            max = Math.Max(current, max);
        }

        return max;
    }
}