public class Solution {
    private static Random rand = new Random();
    private int[] nums;
    private (int, int)[] probs;

    public Solution(int[] w) {
        this.nums = w;
        this.probs = new (int, int)[w.Length];
        
        double sum = w.Sum();
        int current = 0;
        
        for (int index = 0; index < w.Length; ++index) {
            double probability = w[index] / sum;
            int length = (int)Math.Round(probability * 100);
            
            this.probs[index] = (current + 1, current + length);
            current += length;
        }
    }
    
    public int PickIndex() {
        int result = Solution.rand.Next(1, 101);
        int end = this.probs.Length - 1;
        
        for (int index = 0; index < end; ++index) {
            (int low, int high) = this.probs[index];
            
            if (low <= result && high >= result) {
                return index;
            }
        }
        
        return this.probs.Length - 1;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */