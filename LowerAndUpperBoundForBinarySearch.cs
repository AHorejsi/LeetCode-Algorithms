public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] result = new int[2];
        
        result[0] = this.FindBound(nums, target, true);
        result[1] = -1 == result[0] ? -1 : this.FindBound(nums, target, false);
        
        return result;
    }
    
    private int FindBound(int[] nums, int target, bool isLower) {
        int lowIndex = 0;
        int highIndex = nums.Length - 1;
        
        while (lowIndex <= highIndex) {
            int midIndex = (lowIndex + highIndex) / 2;
            
            if (nums[midIndex] > target) {
                highIndex = midIndex - 1;
            }
            else if (nums[midIndex] < target) {
                lowIndex = midIndex + 1;
            }
            else {
                if (isLower) {
                    if (midIndex == lowIndex || nums[midIndex - 1] != target) {
                        return midIndex;
                    }
                    else {
                        highIndex = midIndex - 1;
                    }
                }
                else {
                    if (midIndex == highIndex || nums[midIndex + 1] != target) {
                        return midIndex;
                    }
                    else {
                        lowIndex = midIndex + 1;
                    }
                }
            }
        }
        
        return -1;
    }
}