public class Solution {
    public int[] CountBits(int size) {
        int[] result = new int[size + 1];
        
        for (int index = 1; index <= size; ++index) {
            int bitCount = this.HammingWeight(index);
            result[index] = bitCount;
        }
        
        return result;
    }
    
    private int HammingWeight(long val) {
        long oneZeroOneOne = 0x5555555555555555;
        long twoZeroesTwoOnes = 0x3333333333333333;
        long fourZeroesFourOnes = 0x0f0f0f0f0f0f0f0f;
        
        val -= (val >> 1) & oneZeroOneOne;
        val = (val & twoZeroesTwoOnes) + ((val >> 2) & twoZeroesTwoOnes);
        val = (val + (val >> 4)) & fourZeroesFourOnes; 
        val += val >>  8;
        val += val >> 16;
        val += val >> 32;
        
        return (int)(val & 0x7f);
    }
}