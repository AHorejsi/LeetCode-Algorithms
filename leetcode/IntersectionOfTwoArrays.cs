public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> hashSet = new HashSet<int>();
        HashSet<int> intersection = new HashSet<int>();
        
        if (nums1.Length > nums2.Length) {
            int[] temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }
        
        foreach (int val in nums1) {
            hashSet.Add(val);
        }
        
        foreach (int val in nums2) {
            if (hashSet.Contains(val)) {
                intersection.Add(val);
            }
        }
        
        return intersection.ToArray();
    }
}