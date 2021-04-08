public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {   
        if (nums1.Length > nums2.Length) {
            int[] temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }
        
        Dictionary<int, int> map1 = new Dictionary<int, int>();
        Dictionary<int, int> map2 = new Dictionary<int, int>();
        
        foreach (int val in nums1) {
            if (!map1.TryAdd(val, 1)) {
                ++map1[val];
            }
        }
        
        foreach (int val in nums2) {
            if (!map2.TryAdd(val, 1)) {
                ++map2[val];
            }
        }
        
        List<int> intersection = new List<int>(nums2.Length);
        
        foreach (KeyValuePair<int, int> entry in map1) {
            int count;
            bool success = map2.TryGetValue(entry.Key, out count);
            
            if (success) {
                int amountToAdd = Math.Min(count, entry.Value);
                
                for (int current = 0; current < amountToAdd; ++current) {
                    intersection.Add(entry.Key);
                }
            }
        }
        
        return intersection.ToArray();
    }
}