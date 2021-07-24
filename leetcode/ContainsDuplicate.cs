public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        
        foreach (int value in nums) {
            if (set.Contains(value)) {
                return true;
            }
            
            set.Add(value);
        }
        
        return false;
    }
}