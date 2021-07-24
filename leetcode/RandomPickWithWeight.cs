public class Solution {
    private static Random rand = new Random();
    private int[] nums;
    private IntRange[] probs;

    public Solution(int[] weights) {
        this.nums = weights;
        this.probs = new IntRange[weights.Length];
        
        double sum = weights.Sum();
        int current = 0;
        
        for (int index = 0; index < weights.Length; ++index) {
            double probability = weights[index] / sum;
            int length = (int)Math.Round(probability * 100);
            
            this.probs[index] = new IntRange(current + 1, current + length);
            current += length;
        }
    }
    
    public int PickIndex() {
        int result = Solution.rand.Next(1, 101);
        int end = this.probs.Length - 1;
        
        for (int index = 0; index < end; ++index) {
            IntRange range = this.probs[index];
            
            if (range.Low <= result && range.High >= result) {
                return index;
            }
        }
        
        return this.probs.Length - 1;
    }
}

public struct IntRange {
    public int Low { get; }
    public int High { get; }
    
    public IntRange(int low, int high) {
        this.Low = low;
        this.High = high;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */