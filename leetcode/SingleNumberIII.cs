public class Solution {
    public int[] SingleNumber(int[] nums) {
        int bits = 0;
        
        foreach (int val in nums) {
            bits ^= val;
        }
        
        int diff = bits & (-bits);
        
        int x = 0;
        foreach (int val in nums) {
            if (0 != (val & diff)) {
                x ^= val;
            }
        }
        
        return new int[] { x, bits ^ x };
    }
}