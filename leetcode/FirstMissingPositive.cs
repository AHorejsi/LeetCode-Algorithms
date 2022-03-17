public class Solution {
    public int FirstMissingPositive(int[] nums) {
        // Has the same elements of "nums," but with the negative numbers removed.
        // This is done because the negative numbers have no effect on what the
        // smallest missing positive is
        IEnumerable<int> filteredNums = nums.Where((int num) => num > 0);
        
        if (!filteredNums.Any()) {
            // If filtering all the negative numbers resulted in an empty collection,
            // then all numbers were negative. Therefore, the smallest missing positive
            // is 1 because 1 is the smallest positive number in general
            
            return 1;
        }
        else {
            // Sort all the positive numbers of "nums." After sorting, we can search
            // for gaps between adjacent elements to find the smallest missing positive
            IEnumerable<int> sortedNums = filteredNums.OrderBy((int num) => num);
            
            // If the first number in "sortedNums" after sorting is greater than 1, the
            // smallest missing positive in general is the correct answer. Otherwise,
            // we must search for the smallest missing positive
            return sortedNums.First() > 1 ? 1 : this.Search(sortedNums);
        }
    }
    
    private int Search(IEnumerable<int> nums) {        
        IEnumerator<int> iter = nums.GetEnumerator();
        iter.MoveNext();
        
        // Tracks whether or not there are more elements in the enumerator
        bool more;
        
        // The last value retrieved by the enumerator
        int current;
        
        // If the difference between two adjacent
        // elements is found that is greater than 1, then a gap
        // exists with a missing positive number
        int difference;
        
        // Terminates when a gap greater than 1 is found or if the end
        // of the enumerator is reached
        do {
            // The current value of the iterator
            current = iter.Current;
            
            // Move the enumerator to the next element and keep
            // track of whether or not there are more elements
            more = iter.MoveNext();
            
            // The difference between the last element and the
            // element that the enumerator is currently pointing to.
            // Because "nums" is sorted, this will always be nonnegative
            difference = iter.Current - current;
        } while (more && difference <= 1);
        
        // Return "current + 1" because we need the smallest element
        // NOT present in "nums." The variable "current" points to the
        // smaller of the two last elements returned by the enumerator.
        // We are ensured a positive number because of the previous filtering
        // of negative numbers and sorting in ascending order
        return current + 1;
    }
}
