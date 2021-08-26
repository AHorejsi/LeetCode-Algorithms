public class Solution {
    private sealed class ReverseComparer<T> : IComparer<T> {
        private IComparer<T> comp;
        
        public ReverseComparer() : this(Comparer<T>.Default) {}
        
        public ReverseComparer(IComparer<T> comp) {
            this.comp = comp;
        }
        
        public int Compare(T left, T right) => this.comp.Compare(right, left);
    }
    
    public IList<string> TopKFrequent(string[] words, int amount) {
        SortedDictionary<int, SortedSet<string>> countGroups = this.GroupByCount(words);
        
        int currentCount = 0;
        List<string> output = new List<string>(amount);
        
        foreach (SortedSet<string> wordSet in countGroups.Values) {
            foreach (string word in wordSet) {
                if (currentCount == amount) {
                    return output;
                }
                
                output.Add(word);
                ++currentCount;
            }
        }
        
        return output;
    }
    
    private SortedDictionary<int, SortedSet<string>> GroupByCount(string[] words) {
        Dictionary<string, int> wordCounter = this.CountWords(words);
        SortedDictionary<int, SortedSet<string>> countGroups = new SortedDictionary<int, SortedSet<string>>(new ReverseComparer<int>());
        
        foreach (KeyValuePair<string, int> kvp in wordCounter) {
            SortedSet<string> wordSet;
            
            if (countGroups.TryGetValue(kvp.Value, out wordSet)) {
                wordSet.Add(kvp.Key);
            }
            else {
                countGroups.Add(kvp.Value, new SortedSet<string>() { kvp.Key });
            }
        }
        
        return countGroups;
    }
    
    private Dictionary<string, int> CountWords(string[] words) {
        Dictionary<string, int> wordCounter = new Dictionary<string, int>(words.Length);
        
        foreach (string str in words) {
            if (!wordCounter.TryAdd(str, 1)) {
                ++(wordCounter[str]);
            }
        }
        
        return wordCounter;
    }
}