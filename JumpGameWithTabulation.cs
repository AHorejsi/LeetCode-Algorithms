public class Solution {
    public bool CanJump(int[] nums) {
        BitArray dp = new BitArray(nums.Length);
        dp[nums.Length - 1] = true;

        int lastJumpIndex = nums.Length - 1;

        for (int index = nums.Length - 2; index >= 0; --index) {
            dp[index] = index + nums[index] >= lastJumpIndex;

            if (dp[index]) {
                lastJumpIndex = index;
            }
        }

        return dp[0];
    }
}