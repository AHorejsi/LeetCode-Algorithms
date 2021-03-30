public class Solution {
    public bool IsAnagram(string str1, string str2) {
        if (str1.Length != str2.Length) {
            return false;
        }
        
        Dictionary<char, int> str1ToStr2 = this.AddStr1RemoveStr2(str1, str2);
        Dictionary<char, int> str2ToStr1 = this.AddStr2RemoveStr1(str1, str2);
        
        return 0 == str1ToStr2.Count && 0 == str2ToStr1.Count;
    }
    
    private Dictionary<char, int> AddStr1RemoveStr2(string str1, string str2) {
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
        
        return str1ToStr2;
    }
    
    private Dictionary<char, int> AddStr2RemoveStr1(string str1, string str2) {
        Dictionary<char, int> str2ToStr1 = new Dictionary<char, int>();
        
        foreach (char elem in str2) {
            if (!str2ToStr1.TryAdd(elem, 1)) {
                ++str2ToStr1[elem];
            }
        }
        
        foreach (char elem in str1) {
            if (str2ToStr1.ContainsKey(elem)) {
                --str2ToStr1[elem];
                
                if (0 == str2ToStr1[elem]) {
                    str2ToStr1.Remove(elem);
                }
            }
        }
        
        return str2ToStr1;
    }
}