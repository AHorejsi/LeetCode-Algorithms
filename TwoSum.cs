public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        
        for (int index = 0; index < nums.Length; ++index) {
            int complement = target - nums[index];
            
            if (dict.ContainsKey(complement)) {
                return new int[] { dict[complement], index };
            }
            
            dict.Add(nums[index], index);
        }
        
        return new int[0];
    }
}