public class Solution {
    public bool CanJump(int[] nums) {
        int lastJumpIndex = nums.Length - 1;
        
        for (int index = nums.Length - 2; index >= 0; --index) {
            if (index + nums[index] >= lastJumpIndex) {
                lastJumpIndex = index;
            }
        }
        
        return 0 == lastJumpIndex;
    }
}