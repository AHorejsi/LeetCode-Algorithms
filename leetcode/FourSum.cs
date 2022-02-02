public class Solution {
    // Represents the size of valid solutions to the FourSum problem
    private const int MaxCount = 4;
    
    public IList<IList<int>> FourSum(int[] nums, int target) {
        // Stores all solutions to the FourSum problem
        IList<IList<int>> results = new List<IList<int>>();
        (IList<int> reducedList, IDictionary<int, IList<TwoSum>> twoSumSolutions) = TwoSum.Solutions(nums, target);
        
        foreach (KeyValuePair<int, IList<TwoSum>> kvp in twoSumSolutions) {
            int sum = kvp.Key;
            IList<TwoSum> currentIndices = kvp.Value;
            
            // The value another TwoSum solution needs for the current TwoSum
            // solution to sum up to a valid FourSum solution
            int complement = target - sum;
            
            if (twoSumSolutions.TryGetValue(complement, out IList<TwoSum> otherIndices)) {
                // If "sum" and "complement" are both present in "twoSumSolutions", then iterate
                // through all pairs TwoSum solutions and match them together to make FourSum
                // solutions
                foreach (TwoSum current in currentIndices) {
                    foreach (TwoSum other in otherIndices) {
                        SortedSet<int> indexSet = new SortedSet<int>() { current.FirstIndex, current.SecondIndex, other.FirstIndex, other.SecondIndex };
                        
                        // Ensure that the set of indices refers to 4 distinct elements in "reducedList"
                        if (Solution.MaxCount == indexSet.Count) {
                            IList<int> result = indexSet
                                .Select((int index) => reducedList[index])
                                .ToList();
                            
                            results.Add(result);
                        }
                    }
                }
                
                // The TwoSum solutions corresponding to "complement" have been matched
                // to the TwoSum solutions corresponding to "sum" so "complement" and its
                // corresponding TwoSum solutions can be removed
                twoSumSolutions.Remove(complement);
            }
            
            // The TwoSum solutions corresponding to "sum" have been fully processed,
            // so they can be removed
            twoSumSolutions.Remove(sum);
        }
        
        return results.Distinct(new IListEqualityComparer()).ToList();
    }
    
    // Contains and integer value and a number of instances
    // of the given integer value
    private sealed class ElementCounter {
        // The value being counted
        public int Value { get; }
        // The count of the value, Maximum of 4
        public int Amount { get; }
        
        public ElementCounter(int val, int amount) {
            this.Value = val;
            
            // If the amount is greater than 4, the amount is reduced to 4
            this.Amount = amount >= Solution.MaxCount ? Solution.MaxCount : amount;
        }
    }
    
    // Represents an index pair that act as a solution to
    // the TwoSum problem
    private sealed class TwoSum {
        // The first index of the TwoSum solution
        public int FirstIndex { get; }
        // The second index of the TwoSum solution
        public int SecondIndex { get; }
        
        private TwoSum(int firstIndex, int secondIndex) {
            this.FirstIndex = firstIndex;
            this.SecondIndex = secondIndex;
        }
        
        // Computes the smallest version of the "nums" array needed to find all TwoSum solutions
        // that can then be later used to solve the FourSum problem. This means the list that is output
        // will contain, at most, 4 of a given integer value. All other duplicate values will be removed.
        // Additionally, outputs a map containing all TwoSum solutions mapped to their sums
        public static (IList<int>, IDictionary<int, IList<TwoSum>>) Solutions(int[] nums, int target) {
            // In total, represents a sorted version of "nums" with a value that ocurrs more than 4 times only occurring up to 4 times in this
            IList<int> reducedNums = nums
                .GroupBy((int val) => val) // Group all numerically equal elements together
                .Select((IGrouping<int, int> group) => new ElementCounter(group.Key, group.Count())) // Map each element to its count with any count greater than 4 being reduced to 4
                .OrderBy((ElementCounter counter) => counter.Value) // Sort based on numerical value
                .Select((ElementCounter counter) => Enumerable.Repeat(counter.Value, counter.Amount)) // Create sequences of each value repeated with a length of the value's count
                .Aggregate(Enumerable.Empty<int>(), Enumerable.Concat) // Concatenate each repeated value sequence together
                .ToList();
            
            // Contains all solutions to TwoSum with each solution mapped to its sum
            IDictionary<int, IList<TwoSum>> twoSumSolutions = new Dictionary<int, IList<TwoSum>>();
            
            for (int firstIndex = 0; firstIndex < reducedNums.Count; ++firstIndex) {
                for (int secondIndex = firstIndex + 1; secondIndex < reducedNums.Count; ++secondIndex) {
                    int sum = reducedNums[firstIndex] + reducedNums[secondIndex];
                    TwoSum twoSum = new TwoSum(firstIndex, secondIndex);
                    
                    if (twoSumSolutions.TryGetValue(sum, out IList<TwoSum> twoSumList)) {
                        // If the given sum has already been added to "twoSumSolutions", then
                        // add the index pair (the "TwoSum" instance) to
                        // the already existing list of index pairs that is mapped to the given sum
                        twoSumList.Add(twoSum);
                    }
                    else {
                        // If the given sum has not been added to "twoSumSolutions", then
                        // add the sum as a key and the index pair in a list to "twoSumSolutions"
                        twoSumSolutions.Add(sum, new List<TwoSum>() { twoSum });
                    }
                }
            }
            
            return (reducedNums, twoSumSolutions);
        }
    }
    
    // Checks if two lists have the same elements in the same order
    private sealed class IListEqualityComparer : IEqualityComparer<IList<int>> {
        public bool Equals(IList<int> left, IList<int> right) => left.SequenceEqual(right);
        
        public int GetHashCode(IList<int> list) {
            HashCode hasher = new HashCode();
            
            foreach (int val in list) {
                hasher.Add(val);
            }
            
            return hasher.ToHashCode();
        }
    }
}