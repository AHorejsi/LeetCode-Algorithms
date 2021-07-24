public class Solution {
    public int SubarraySum(int[] nums, int targetSum) {
        int subarrayCount = 0;
        int currentSum = 0;
        
        Dictionary<int, int> map = new Dictionary<int, int>();
        map.Add(0, 1);
        
        for (int i = 0; i < nums.Length; ++i) {
            currentSum += nums[i];
            
            if (map.ContainsKey(currentSum - targetSum)) {
                subarrayCount += map[currentSum - targetSum];
            }
            
            int count;
            if (map.TryGetValue(currentSum, out count)) {
                ++(map[currentSum]);
            }
            else {
                map.Add(currentSum, 1);
            }
        }
        
        return subarrayCount;
    }
}