public class Solution {
    public int SingleNumber(int[] nums) {
        int bitVector = 0;
        
        foreach (int val in nums) {
            bitVector ^= val;
        }
        
        return bitVector;
    }
}