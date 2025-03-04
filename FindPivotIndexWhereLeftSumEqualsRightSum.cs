/*
 * Given an array of integers nums, calculate the pivot index of this array.
 *
 * The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.
 *
 * If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
 *
 * Return the leftmost pivot index. If no such index exists, return -1.
*/
public class Solution {
    public int PivotIndex(int[] nums) {        
        int leftSum = 0;
        int rightSum = nums.Skip(1).Sum();
        
        if (leftSum == rightSum) {
            return 0;
        }
        
        for (int index = 1; index < nums.Length; ++index) {
            leftSum += nums[index - 1];
            rightSum -= nums[index];
            
            if (leftSum == rightSum) {
                return index;
            }
        }
        
        return -1;
    }
}