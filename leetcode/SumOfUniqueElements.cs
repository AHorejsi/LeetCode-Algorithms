public class Solution {
    public int SumOfUnique(int[] nums) {
        (int[] counts, int minValue) = this.CountNums(nums);
        int sum = 0;
        
        foreach (int val in nums) {
            int amount = counts[val - minValue];
            
            if (1 == amount) {
                sum += val;
            }
        }
        
        return sum;
    }
    
    private (int[], int) CountNums(int[] nums) {
        int minValue = nums.Min();
        int maxValue = nums.Max();
        
        int[] counts = new int[maxValue - minValue + 1];
        
        foreach (int val in nums) {
            ++(counts[val - minValue]);
        }
        
        return (counts, minValue);
    }
}