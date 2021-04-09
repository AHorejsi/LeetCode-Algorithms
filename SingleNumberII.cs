public class Solution {
    public int SingleNumber(int[] nums) {
        int seenOnce = 0;
        int seenTwice = 0;
        
        foreach (int val in nums) {
            seenOnce = ~seenTwice & (seenOnce ^ val);
            seenTwice = ~seenOnce & (seenTwice ^ val);
        }
        
        return seenOnce;
    }
}