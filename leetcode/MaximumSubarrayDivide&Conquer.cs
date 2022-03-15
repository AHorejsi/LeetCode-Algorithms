public class Solution {
    public int MaxSubArray(int[] nums) => this.FindMaxSubarraySum(nums, 0, nums.Length);
    
    private int FindMaxSubarraySum(int[] nums, int lowIndex, int highIndex) {
        // The number of elements in the current subarray
        int count = highIndex - lowIndex;
        
        if (1 == count) {
            // If the number of elements in the current subarray is 1,
            // then there is only one number to sum up
            return nums[lowIndex];
        }
        else {
            // The midpoint of the current subarray
            int midIndex = (lowIndex + highIndex) / 2;
            
            // The sum of the maximum subarray of the current subarray's left half
            int leftMaxSum = this.FindMaxSubarraySum(nums, lowIndex, midIndex);
            
            // The sum of the maximum subarray of the current subarray's right half
            int rightMaxSum = this.FindMaxSubarraySum(nums, midIndex, highIndex);
            
            // The sum of the maximum subarray that crosses the current subarray's left and right halves
            int crossMaxSum = this.CrossMaxSubarraySum(nums, lowIndex, midIndex, highIndex);
            
            // Max of the three current maximum subarrays
            return new[] { leftMaxSum, rightMaxSum, crossMaxSum }.Max();
        }
    }
    
    private int CrossMaxSubarraySum(int[] nums, int lowIndex, int midIndex, int highIndex) {
        // The best possible sum from the left half of the current subarray.
        // Initialized to the minimum int value to ensure it gets overwritten
        int leftSum = int.MinValue;
        
        // The best possible sum from the right half of the current subarray
        // Initialized to the minimum int value to ensure it gets overwritten
        int rightSum = int.MinValue;
        
        _ = nums
            .Skip(lowIndex) // Remove all elements before the current subarray's left half
            .Take(midIndex - lowIndex) // Take all elements in the current subarray's left half
            .Reverse() // Reverse the order
            .Aggregate(0, (int val, int total) => { // Compute the best possible sum of the current subarray's left half
                int newTotal = total + val;
                
                if (newTotal > leftSum) {
                    leftSum = newTotal;
                }
                
                return newTotal;
            });
        _ = nums
            .Skip(midIndex) // Remove all elements before the current subarray's right half
            .Take(highIndex - midIndex) // Take all elements in the current subarray's right half
            .Aggregate(0, (int val, int total) => { // Compute the best possible sum of the current subarray's right half
                int newTotal = total + val;
                
                if (newTotal > rightSum) {
                    rightSum = newTotal;
                }
                
                return newTotal;
            });
        
        // Combine both best sums
        return leftSum + rightSum;
    }
}
