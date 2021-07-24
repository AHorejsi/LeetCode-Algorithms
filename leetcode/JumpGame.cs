public class Solution {
    public bool CanJump(int[] nums) => this.CanJump(nums, 0, new HashSet<int>());
    
    private bool CanJump(int[] nums, int currentIndex, HashSet<int> deadEnds) {
        if (deadEnds.Contains(currentIndex)) {
            return false;    
        }
        
        if (nums.Length - 1 == currentIndex) {
            return true;
        }
        
        for (int stepSize = nums[currentIndex]; stepSize > 0; --stepSize) {
            int newIndex = stepSize + currentIndex;
            
            if (newIndex < nums.Length) {
                bool success = this.CanJump(nums, newIndex, deadEnds);
            
                if (success) {
                    return true;
                }
            }
        }
        
        deadEnds.Add(currentIndex);
        
        return false;
    }
}