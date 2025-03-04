public class Solution {
    public int LongestConsecutive(int[] nums) {
        // Combination of sorting and removing duplicates ensures that
        // adjacent values are next to each other. Loop below needs both
        IEnumerator<int> iter = nums
            .Distinct()
            .OrderBy((int val) => val)
            .GetEnumerator();
        
        // Length of the current sequence of numbers
        int currentLength = 1;
        
        // Length of the longest sequence of numbers currently found
        int longestLength = 0;
        
        // Indicates whether or not there are more elements to read.
        // Need to treat the enumerator as a peeking enumerator so
        // the current element needs to be read and the next element
        // needs to be read. The next element becomes the current element
        // of the next iteration of the loop
        bool more = iter.MoveNext();
        
        while (more) {
            // Current element
            int first = iter.Current;
            
            more = iter.MoveNext();
            
            // Next element. Guaranteed to be larger that
            // "first" because of previous sorting
            int second = iter.Current;
            
            if (1 == second - first) {
                // Check the distance between "first" and "second."
                // If the distance equals 1, then "first" and "second"
                // are adjacent to each other and therefore are part of
                // the same sequence. For this to work, all values need
                // to be distinct because values adjacent to each other
                // could be equal and therefore still part of the same sequence
                
                ++currentLength;
            }
            else {
                
                // If distance is greater than 1, then the current sequence has ended
                currentLength = 1;
            }
            
            // If the length of the current sequence is greater than the length
            // of the longest sequence that has been seen, record the new longest sequence
            if (currentLength > longestLength) {
                longestLength = currentLength;
            }
        }
        
        return longestLength;
    }
}
