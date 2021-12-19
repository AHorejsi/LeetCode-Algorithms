public class Solution {
    private sealed class ArrayEqualityComparer : IEqualityComparer<int[]> {
        public bool Equals(int[] left, int[] right) => left.SequenceEqual(right);
        
        public int GetHashCode(int[] letterCounts) {
            HashCode hasher = new HashCode();
            
            foreach (int count in letterCounts) {
                hasher.Add(count);
            }
            
            return hasher.ToHashCode();
        }
    }
    
    public IList<IList<string>> GroupAnagrams(string[] strs) => this.FindAnagrams(strs).Values.ToList();
    
    private IDictionary<int[], IList<string>> FindAnagrams(string[] strs) {
        int alphabetCount = 26;
        int minLetter = 'a';
        
        IDictionary<int[], IList<string>> anagrams = new Dictionary<int[], IList<string>>(strs.Length, new ArrayEqualityComparer());
        
        foreach (string word in strs) {
            int[] counts = new int[alphabetCount];
            
            foreach (char letter in word) {
                ++(counts[letter - minLetter]);
            }
            
            if (anagrams.TryGetValue(counts, out IList<string> list)) {
                list.Add(word);
            }
            else {
                anagrams.Add(counts, new List<string> { word });
            }
        }
        
        return anagrams;
    }
}