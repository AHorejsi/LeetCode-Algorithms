public class Solution {
    public int FindTargetSumWays(int[] nums, int target) => this.CalcExpression(nums, target, 0, 0, 0);
    
    private int CalcExpression(int[] nums, int target, int index, int currentSum, int count) {
        if (nums.Length == index) {
            return count + (currentSum == target ? 1 : 0);
        }
        
        int nextIndex = index + 1;
        
        count = this.CalcExpression(nums, target, nextIndex, currentSum + nums[index], count);
        count = this.CalcExpression(nums, target, nextIndex, currentSum - nums[index], count);
        
        return count;
    }
}