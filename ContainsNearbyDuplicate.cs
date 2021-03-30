public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int distance) {
        Dictionary<int, int> table = new Dictionary<int, int>();
        
        for (int index = 0; index < nums.Length; ++index) {
            if (!table.TryAdd(nums[index], index)) {
                int indexOfDuplicate = table[nums[index]];
                
                if (Math.Abs(index - indexOfDuplicate) <= distance) {
                    return true;
                }
                else {
                    table[nums[index]] = index;
                }
            }   
        }
        
        return false;
    }
}