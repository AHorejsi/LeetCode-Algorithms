public class Solution {
    public int FindTargetSumWays(int[] nums, int target) => this.CalcExpression(nums, target, 0, 0, 0);
    
    private int CalcExpression(int[] nums, int target, int index, int currentSum, int count) {
        if (nums.Length == index) {
            return (currentSum == target) ? count + 1 : count;
        }
        
        count = this.CalcExpression(nums, target, index + 1, currentSum + nums[index], count);
        count = this.CalcExpression(nums, target, index + 1, currentSum - nums[index], count);
        
        return count;
    }
}