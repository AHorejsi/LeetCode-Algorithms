public class Solution {
    private static readonly Random rand = new Random();
    private readonly List<Range> ranges;

    public Solution(int max, int[] blacklist) {
        this.ranges = new List<Range>();

        var low = 0;

        foreach (var high in blacklist.OrderBy(number => number)) {
            this.AddRange(low, high);

            low = high + 1;
        }

        this.AddRange(low, max);
    }

    private void AddRange(int low, int high) {
        // If "low" and "high" are equal, then range is empty
        if (low != high) {
            this.ranges.Add(new Range(low, high));
        }
    }
    
    public int Pick() {
        var index = Solution.rand.Next(0, this.ranges.Count);
        var range = this.ranges[index];
        
        return Solution.rand.Next(range.Low, range.High);
    }

    private struct Range {
        public int Low { get; init; }
        public int High { get; init; }

        public Range(int low, int high) {
            this.Low = low;
            this.High = high;
        }
    }
}
