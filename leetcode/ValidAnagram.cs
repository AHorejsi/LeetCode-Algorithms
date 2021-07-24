public class Solution {
    public bool IsAnagram(string str1, string str2) {
        if (str1.Length != str2.Length) {
            return false;
        }
		
		Dictionary<char, int> str1ToStr2 = new Dictionary<char, int>();
        
        foreach (char elem in str1) {
            if (!str1ToStr2.TryAdd(elem, 1)) {
                ++str1ToStr2[elem];
            }
        }
        
        foreach (char elem in str2) {
            if (str1ToStr2.ContainsKey(elem)) {
                --str1ToStr2[elem];
                
                if (0 == str1ToStr2[elem]) {
                    str1ToStr2.Remove(elem);
                }
            }
        }
        
        return 0 == str1ToStr2.Count;
    }
}