public class Solution {
    public bool CanJump(int[] nums) => this.JumpGame(nums, 0, new HashSet<int>());
    
    private bool JumpGame(int[] nums, int currentIndex, HashSet<int> deadEnds) {
        if (currentIndex >= nums.Length - 1) {
            return true;
        }
        
        if (deadEnds.Contains(currentIndex)) {
            return false;
        }
        
        for (int jumpSize = nums[currentIndex]; jumpSize > 0; --jumpSize) {
            int newIndex = currentIndex + jumpSize;
            
            if (this.JumpGame(nums, newIndex, deadEnds)) {
                return true;
            }
        }
        
        deadEnds.Add(currentIndex);
        
        return false;
    }
}