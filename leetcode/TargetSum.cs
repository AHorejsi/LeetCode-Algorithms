public class Solution {
    public int FindTargetSumWays(int[] nums, int target) => this.CalcExpression(nums, target, 0, 0);
    
    private int CalcExpression(int[] nums, int target, int index, int currentSum) {
        if (nums.Length == index) {
            return currentSum == target ? 1 : 0;
        }
        
        int nextIndex = index + 1;
        int count = 0;
        
        count += this.CalcExpression(nums, target, nextIndex, currentSum + nums[index]);
        count += this.CalcExpression(nums, target, nextIndex, currentSum - nums[index]);
        
        return count;
    }
}