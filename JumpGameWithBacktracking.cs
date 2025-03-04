public class Solution {
    public bool CanJump(int[] nums) => this.JumpGame(nums, 0);
    
    private bool JumpGame(int[] nums, int currentIndex) {
        if (currentIndex >= nums.Length - 1) {
            return true;
        }
        
        for (int jumpSize = nums[currentIndex]; jumpSize > 0; --jumpSize) {
            int newIndex = currentIndex + jumpSize;
            
            if (this.JumpGame(nums, newIndex)) {
                return true;
            }
        }
        
        return false;
    }
}