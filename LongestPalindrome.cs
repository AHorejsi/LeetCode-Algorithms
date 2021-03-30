public class Solution {
    public int LongestPalindrome(string str) {
        Dictionary<char, int> multiset = new Dictionary<char, int>();
        
        foreach (char elem in str) {
            if (!multiset.TryAdd(elem, 1)) {
                ++multiset[elem];
            }
        }
        
        int result = 0;
        
        foreach (KeyValuePair<char, int> entry in multiset) {
            result += entry.Value / 2 * 2;
            
            if (0 == result % 2 && 1 == entry.Value % 2) {
                ++result;
            }
        }
        
        return result;
    }
}