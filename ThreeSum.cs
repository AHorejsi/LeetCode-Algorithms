public class Solution {
    private class IntListEqualityComparer : IEqualityComparer<IList<int>> {
        public bool Equals(IList<int> left, IList<int> right) {
            for (int index = 0; index < left.Count; ++index) {
                if (left[index] != right[index]) {
                    return false;
                }
            }
            
            return true;
        }
        
        public int GetHashCode(IList<int> list) {
            int modifier = 31;
            int hashCode = 0;
            
            for (int index = 0; index < list.Count; ++index) {
                hashCode += modifier * (int)Math.Pow(list[index], index);
            }
            
            return hashCode;
        }
    }
    
    public IList<IList<int>> ThreeSum(int[] nums) {
        var result = new HashSet<IList<int>>(new IntListEqualityComparer());
        var duplicates = new HashSet<int>();
        var seen = new Dictionary<int, int>();
        
        for (var i = 0; i < nums.Length; ++i) {
            if (duplicates.Add(nums[i])) {
                for (int j = i + 1; j < nums.Length; ++j) {
                    int complement = -nums[i] - nums[j];
                    
                    if (seen.ContainsKey(complement) && seen[complement] == i) {
                        var triplet = new int[] { nums[i], nums[j], complement };
                        Array.Sort(triplet);
                        result.Add(triplet);
                    }
                    
                    if (!seen.TryAdd(nums[j], i)) {
                        seen[nums[j]] = i;
                    }
                }
            }
        }
        
        return new List<IList<int>>(result);
    }
}