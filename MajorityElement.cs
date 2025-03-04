public class Solution {
    public int MajorityElement(int[] nums) => this.MajorityElement(nums, 0, nums.Length);
    
    private int MajorityElement(int[] nums, int low, int high) {
        int size = high - low;
        
        if (1 == size) {
            return nums[low];
        }
        else {
            int mid = low + size / 2;
            
            int leftElement = this.MajorityElement(nums, low, mid);
            int rightElement = this.MajorityElement(nums, mid, high);
            
            ArraySegment<int> portion = new ArraySegment<int>(nums, low, high - low);
            
            int leftCount = portion.Count((int val) => val == leftElement);
            int rightCount = portion.Count((int val) => val == rightElement);
            
            return leftCount > rightCount ? leftElement : rightElement;
        }
    }
}