public class Solution {
    private static readonly Random rand = new Random();
    private readonly List<float> cdf;

    public Solution(int[] weights) {
        this.cdf = this.ComputeCdf(weights);
    }

    private List<float> ComputeCdf(int[] weights) {
        var cdf = new List<float>(weights.Length);
        var sum = weights.Sum();
        var probs = weights.Select(weight => weight / (float)sum);

        cdf.Add(probs.First());

        foreach (var probability in probs.Skip(1)) {
            cdf.Add(probability + cdf.Last());
        }

        return cdf;
    }
    
    public int PickIndex() {
        var rand = Solution.rand.NextSingle();

        var low = 0;
        var high = this.cdf.Count - 1;

        while (low <= high) {
            var mid = (low + high) / 2;
            var value = this.cdf[mid];

            if (rand > value) {
                low = mid + 1;
            }
            else if (rand < value) {
                high = mid - 1;
            }
            else {
                return mid;
            }
        }

        return high + 1;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */
