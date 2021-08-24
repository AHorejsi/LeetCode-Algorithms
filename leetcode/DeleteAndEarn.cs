public class Solution {
    public int DeleteAndEarn(int[] nums) {
        int[] counts = this.Count(nums);
        
        int avoid = 0;
        int use = 0;
        int prev = -1;
        
        for (int val = 0; val < counts.Length; ++val) {
            if (counts[val] > 0) {
                int max = Math.Max(avoid, use);
                
                if (val - 1 != prev) {
                    use = val * counts[val] + max;
                }
                else {
                    use = val * counts[val] + avoid;
                }
                
                avoid = max;
                prev = val;
            }
        }
        
        return Math.Max(avoid, use);
    }
    
    private int[] Count(int[] nums) {
        int[] counts = new int[nums.Max() + 1];
        
        foreach (int val in nums) {
            ++(counts[val]);
        }
        
        return counts;
    }
}