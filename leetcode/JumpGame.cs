public class Solution {
    public bool CanJump(int[] nums) {
        int lastPos = nums.Length - 1;
        
        for (int index = lastPos; index >= 0; --index) {
            if (index + nums[index] >= lastPos) {
                lastPos = index;
            }
        }
        
        return 0 == lastPos;
    }
}