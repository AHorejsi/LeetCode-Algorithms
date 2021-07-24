public class Solution {
    public int FirstMissingPositive(int[] nums) {        
        IEnumerable<int> sortedNums = nums.Where(num => num > 0).OrderBy(num => num);
        
        return !sortedNums.Any() ? 1 : this.Search(sortedNums);
    }
    
    private int Search(IEnumerable<int> nums) {        
        if (nums.First() > 1) {
            return 1;
        }
        
        IEnumerator<int> iter = nums.GetEnumerator();
        iter.MoveNext();
        
        bool more;
        int current;
        int difference;
        
        do {
            current = iter.Current;
            
            more = iter.MoveNext();
            
            difference = iter.Current - current;
        } while (more && difference <= 1);
        
        return current + 1;
    }
}