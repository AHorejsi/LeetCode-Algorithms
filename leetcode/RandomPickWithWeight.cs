public class Solution {
    private static Random rand = new Random();
    private int[] nums;
    private IntRange[] probs;

    public Solution(int[] weights) {
        this.nums = weights;
        this.probs = new IntRange[weights.Length];
        
        var sum = weights.Sum();
        var current = 0;
        
        for (int index = 0; index < weights.Length; ++index) {
            var probability = weights[index] / sum;
            var length = (int)Math.Round(probability * 100);
            
            this.probs[index] = new IntRange(current + 1, current + length);
            current += length;
        }
    }
    
    public int PickIndex() {
        var result = Solution.rand.Next(1, 101);
        var end = this.probs.Length - 1;
        
        for (var index = 0; index < end; ++index) {
            var range = this.probs[index];
            
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
