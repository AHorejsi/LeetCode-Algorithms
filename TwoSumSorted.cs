public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int left = 0;
        int right = numbers.Length - 1;
        
        while (numbers[left] + numbers[right] != target) {
            int sum = numbers[left] + numbers[right];
            
            if (sum > target) {
                --right;
            }
            else {
                ++left;
            }
        }
        
        return new int[] { left + 1, right + 1 };
    }
}