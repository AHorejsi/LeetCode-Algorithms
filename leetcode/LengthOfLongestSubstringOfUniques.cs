public class Solution {
    public int LengthOfLongestSubstring(string str) {
        int result = 0;
        
        HashSet<char> set = new HashSet<char>();
        int i = 0;
        int j = 0;
        
        while (i < str.Length && j < str.Length) {
            if (set.Contains(str[j])) {
                set.Remove(str[i]);
                ++i;
            }
            else {
               set.Add(str[j]);
                ++j;
                
                result = Math.Max(result, j - i); 
            }
        }
        
        return result;
    }
}