public class Solution {
    public int FindDuplicate(int[] nums) {
        BitArray bitArray = new BitArray(nums.Length);
        
        foreach (int val in nums) {
            if (bitArray[val]) {
                return val;
            }
            else {
                bitArray[val] = true;
            }
        }
        
        return -1;
    }
}