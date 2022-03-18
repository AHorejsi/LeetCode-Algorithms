public class Solution {
    public int MaxSubArray(int[] nums) {
        // The number of elements in "nums"
        int length = nums.Length;
        
        // The value used to store the maximum subarray sum
        // currently found. Initialized to "int.MinValue"
        // to ensure that it gets overwritten by some
        // actual value in the array
        int maxSubarraySum = int.MinValue;
        
        // Contains values that correspond to the sums of the subarrays of "nums"
        int[] sums = nums.ToArray();
        
        // Generates the sums of subarrays of increasing length.
        // The "range" variable represents the length of the current
        // subarrays whose sum is to be computed
        foreach (int range in Enumerable.Range(1, nums.Length)) {
            // Maximum subarray sum for the current subarrays of length "range."
            // The use of "SkipLast" is there because, with each computation of
            // successively larger subarray sums, we reduced the total number of
            // subarrays by one
            int newMaxSubarraySum = sums.SkipLast(range - 1).Max();
            
            if (newMaxSubarraySum > maxSubarraySum) {
                // Only save the new maximum subarray sum if it is greater
                // the maximum subarray sum of previous, smaller subarrays
                maxSubarraySum = newMaxSubarraySum;
            }
            
            // Compute the sums of all subarrays of length "range + 1"
            this.ComputeNewSums(sums, nums, range, length - range);
        }
        
        // The previous loop only computes the sum of subarrays
        // smaller than the whole array. However, the whole array
        // still is considered a subarray so we must account for it
        int wholeArraySum = sums[0];
        if (wholeArraySum > maxSubarraySum) {
            maxSubarraySum = wholeArraySum;
        }
        
        return maxSubarraySum;
    }
    
    private void ComputeNewSums(int[] sums, int[] nums, int range, int endIndex) {
        // Add the next value in the prefix to each existing prefix sum
        for (int index = 0; index < endIndex; ++index) {
            sums[index] += nums[index + range];
        }
    }
}
