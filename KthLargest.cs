public class Solution {
    public int FindKthLargest(int[] nums, int kth) => this.QuickSelect(nums, kth - 1, 0, nums.Length - 1);
    
    private int QuickSelect(int[] nums, int kth, int lowIndex, int highIndex) {
        int partitionIndex = this.Partition(nums, lowIndex, highIndex);
        
        if (partitionIndex == kth) {
            return nums[partitionIndex];
        }
        else if (partitionIndex > kth) {
            return this.QuickSelect(nums, kth, lowIndex, partitionIndex - 1);
        }
        else {
            return this.QuickSelect(nums, kth, partitionIndex + 1, highIndex);
        }
    }
    
    private int Partition(int[] nums, int lowIndex, int highIndex) {
        int pivotIndex = this.SelectPivot(nums, lowIndex, highIndex);
        this.Swap(nums, pivotIndex, highIndex);
        
        int pivot = nums[highIndex];
        int i = lowIndex - 1;
        
        for (int j = lowIndex; j < highIndex; ++j) {
            if (nums[j] >= pivot) {
                ++i;
                this.Swap(nums, i, j);
            }
        }
        
        int swapIndex = i + 1;
        this.Swap(nums, swapIndex, highIndex);
        
        return swapIndex;
    }
    
    private int SelectPivot(int[] nums, int lowIndex, int highIndex) {
        int midIndex = lowIndex + (highIndex - lowIndex + 1) / 2;
        
        if (nums[highIndex] > nums[lowIndex]) {
            this.Swap(nums, lowIndex, highIndex);
        }
        if (nums[midIndex] > nums[lowIndex]) {
            this.Swap(nums, midIndex, lowIndex);
        }
        if (nums[highIndex] > nums[midIndex]) {
            this.Swap(nums, highIndex, midIndex);
        }
        
        return midIndex;
    }
    
    private void Swap(int[] nums, int index1, int index2) {
        if (index1 != index2) {
            nums[index1] ^= nums[index2];
            nums[index2] ^= nums[index1];
            nums[index1] ^= nums[index2];
        }
    }
}