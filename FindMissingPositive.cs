public class Solution {
    public int FirstMissingPositive(int[] nums) {
        if (0 == nums.Length) {
            return 1;
        }
        
        int min = nums.Min();
        int max = nums.Max();
        
        if (min <= 0 && max <= 0) {
            return 1;
        }
        else if (min >= 0 && max >= 0) {
            return this.WithAllPositive(nums);
        }
        else {
            return this.WithMix(nums);
        }
    }
    
    private int WithAllPositive(int[] nums) {
        SortedSet<int> set = new SortedSet<int>(nums);
        
        if (set.First() > 1) {
            return 1;
        }
        
        IEnumerator<int> iter = set.GetEnumerator();
        bool more;
        
        while (true) {
            int current = iter.Current;
            
            more = iter.MoveNext();
            int next = iter.Current;
            
            int difference = next - current;
            
            if (difference > 1) {
                return current + 1;
            }
            
            if (!more) {
                break;
            }
        }
        
        return set.Last() + 1;
    }
    
    private int WithMix(int[] nums) {
        SortedSet<int> positives = new SortedSet<int>(nums.Where(num => num > 0));
        
        int current = 1;
        IEnumerator<int> iter = positives.GetEnumerator();
        
        while (iter.MoveNext() && iter.Current == current) {
            ++current;
        }
        
        return current;
    }
}