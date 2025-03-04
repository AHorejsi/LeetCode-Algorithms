public class Solution {
    public int SumOfUnique(int[] nums) {
		// Tracks the numbers in the "nums" array that have been seen exactly once
        HashSet<int> seenOnce = new HashSet<int>(nums.Length);
		
		// Tracks the numbers in the "nums" array that have been seen twice
        HashSet<int> seenTwice = new HashSet<int>(nums.Length);
        
        foreach (int val in nums) {
			// If a number has been seen twice, then all future occurrences
			// of it can be safely ignored, because numbers that have occurred
			// 2, 3 or infinity times are all treated the same, because they
			// did not occur once. Therefore, we can stop counting after the
			// second occurrence of a number has been seen
            if (!seenTwice.Contains(val)) {
                if (seenOnce.Contains(val)) {
					// If the "seenOnce" set already contains the number, then
					// this is the second occurrence of the number. Therefore
					// the number should be moved from the "seenOnce" set to the
					// "seenTwice" set.
                    seenOnce.Remove(val);
                    seenTwice.Add(val);
                }
                else {
					// If the "seenOnce" set does not contain the number, then this
					// is the first time it has been seen. Therefore, we add it to the
					// "seenOnce" set
                    seenOnce.Add(val);
                }
            }
        }
        
        return seenOnce.Sum();
    }
}