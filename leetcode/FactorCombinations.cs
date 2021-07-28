public class Solution {
    private sealed class IntIListEqualityComparer : IEqualityComparer<IList<int>> {
        private const int HashModifier = 31;
        
        public bool Equals(IList<int> left, IList<int> right) {
            if (left.Count != right.Count) {
                return false;
            }
            
            Dictionary<int, int> counter = new Dictionary<int, int>(left.Count);
            
            foreach (int val in left) {
                if (!counter.TryAdd(val, 1)) {
                    ++(counter[val]);
                }
            }
            
            foreach (int val in right) {
                if (counter.ContainsKey(val)) {
                    --(counter[val]);
                    
                    if (0 == counter[val]) {
                        counter.Remove(val);
                    }
                }
                else {
                    return false;
                }
            }
            
            return 0 == counter.Count;
        }
        
        public int GetHashCode(IList<int> list) => list.Sum();
    }
    
    public IList<IList<int>> GetFactors(int num) {
        IList<int> primeFactors = this.FindPrimeFactors(num);
        IList<IList<int>> solutions = new List<IList<int>>();
        
        if (primeFactors.Count > 1) {
            this.FindFactors(primeFactors, solutions, new HashSet<IList<int>>(new IntIListEqualityComparer()));
        }
        
        return solutions;
    }
    
    private IList<int> FindPrimeFactors(int num) {
        IList<int> primeFactors = new List<int>();
        int factor = 2;
        
        while (num > 1) {
            if (0 == num % factor) {
                num /= factor;
                primeFactors.Add(factor);
            }
            else {
                ++factor;
            }
        }
        
        return primeFactors;
    }
    
    private void FindFactors(IList<int> currentFactors, IList<IList<int>> solutions, HashSet<IList<int>> seen) {        
        if (currentFactors.Count >= 2) {            
            if (!seen.Contains(currentFactors)) {
                solutions.Add(currentFactors);
                seen.Add(currentFactors);

                for (int i = 0; i < currentFactors.Count; ++i) {
                    for (int j = i + 1; j < currentFactors.Count; ++j) {
                        IList<int> newFactors = currentFactors.Take(i).ToList();
                        newFactors.Add(currentFactors[i] * currentFactors[j]);

                        for (int k = i + 1; k < currentFactors.Count; ++k) {
                            if (k != j) {
                                newFactors.Add(currentFactors[k]);
                            }
                        }

                        this.FindFactors(newFactors, solutions, seen);
                    }
                }
            }
        }
    }
}