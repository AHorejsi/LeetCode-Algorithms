public class Solution {
    public int HammingWeight(uint val) {
        int bitCount = 0;
        
        while (0 != val) {
            ++bitCount;
            val &= val - 1;
        }
        
        return bitCount;
    }
}