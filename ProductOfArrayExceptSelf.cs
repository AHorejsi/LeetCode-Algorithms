public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] result = new int[nums.Length];
        int indexOfZero = Array.IndexOf(nums, 0);
        
        if (-1 != indexOfZero) {
            result[indexOfZero] = 1;
            
            for (int index = 0; index < nums.Length; ++index) {
                if (index != indexOfZero) {
                    result[indexOfZero] *= nums[index];
                }
            }
        }
        else {
            int product = this.FindProductOfAll(nums);
        
            for (int index = 0; index < nums.Length; ++index) {
                result[index] = product / nums[index];
            }
        }
        
        return result;
    }
    
    private int FindProductOfAll(int[] nums) {
        int product = 1;
        
        foreach (int value in nums) {
            product *= value;
        }
        
        return product;
    }
}