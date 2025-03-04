public class Solution {
    public int Search(int[] nums, int target) {
        if (1 == nums.Length) {
            return nums[0] == target ? 0 : -1;
        }
        
        int rotationIndex = this.FindRotationIndex(nums, 0, nums.Length - 1);
        int result;
        
        if (nums[rotationIndex] == target) {
            result = rotationIndex;
        }
        else if (0 == rotationIndex) {
            result = Array.BinarySearch(nums, target);
        }
        else if (target < nums[0]) { // If the target is less than the first element, then the target is not in the left subarray
            result = Array.BinarySearch(nums, rotationIndex, nums.Length - rotationIndex, target);
        }
        else {
            result = Array.BinarySearch(nums, 0, rotationIndex, target);
        }
        
        return result < 0 ? -1 : result;
    }
    
    private int FindRotationIndex(int[] nums, int start, int end) {
        // Means array is not rotated
        if (nums[start] < nums[end]) {
            return 0;
        }
        
        while (start <= end) {
            int mid = (start + end) / 2;
            
            if (nums[mid] > nums[mid + 1]) {
                return mid + 1;
            }
            else if (nums[mid] < nums[start]) {
                end = mid - 1;
            }
            else {
                start = mid + 1;
            }
        }
        
        return 0;
    }
}