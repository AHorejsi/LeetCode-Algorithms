public class Solution {
    public int MissingNumber(int[] nums) {
        int actualSum = 0;
        int expectedSum = 0;
        
        for (int index = 0; index < nums.Length; ++index) {
            actualSum += nums[index];
            expectedSum += index + 1;
        }
        
        return expectedSum - actualSum;
    }
}
