public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        // The length of the "nums" array
        int length = nums.Length;
        
        // The list that will store the output. Each element
        // represents a range of unique values in the sorted
        // "nums" array
        List<string> ranges = new List<string>(length);
        
        // The index of the first element of the current range
        int startIndex = 0;
        
        while (startIndex < length) {
            // The casts here are done to account for int overflows
            if (length - 1 == startIndex || (long)nums[startIndex + 1] - (long)nums[startIndex] > 1) {
                // There are two situations where a range will consist of only a single element. The first
                // is whether or not there is only one element in "nums" left to be traversed. The other is
                // if the element pointed to by "startIndex" is not one less than "startIndex + 1".
                
                // Add only the current element to "ranges"
                ranges.Add(nums[startIndex].ToString());
                
                // Increment because only one element was added
                ++startIndex;
            }
            else {
                // The index of the last element of the current range
                int endIndex = startIndex + 1;
                
                // Increments "endIndex" until the end of "nums" is reached or the difference
                // between "nums[endIndex + 1]" and "nums[endIndex]" is greater than 1, which would
                // mean that the end of the current range has been reached
                // The casts here are done to account for int overflows
                while (endIndex < length - 1 && 1 == (long)nums[endIndex + 1] - (long)nums[endIndex]) {
                    ++endIndex;
                }
                
                // Add the computed range to "ranges"
                ranges.Add($"{nums[startIndex]}->{nums[endIndex]}");
                
                // Set "startIndex" to the start of the next range
                startIndex = endIndex + 1;
            }
        }
        
        return ranges;
    }
}