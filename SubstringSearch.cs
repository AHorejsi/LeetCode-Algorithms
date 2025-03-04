public class Solution {
    public int StrStr(string haystack, string needle) {
        if ("" == needle) {
            return 0;
        }
        else if (haystack.Length < needle.Length) {
            return -1;
        }
        else {
            return this.SubstringSearch(haystack, needle);
        }
    }
    
    private int SubstringSearch(string haystack, string needle) {
        int endLength = haystack.Length - needle.Length;
        
        for (int index = 0; index <= endLength; ++index) {
            if (needle[0] == haystack[index] && this.CheckSubstring(haystack, needle, index)) {
                return index;
            }
        }

        return -1;
    }
    
    private bool CheckSubstring(string haystack, string needle, int haystackIndex) {
        int needleIndex = 1;
        ++haystackIndex;
        
        while (needleIndex < needle.Length && haystackIndex < haystack.Length) {
            if (needle[needleIndex] != haystack[haystackIndex]) {
                break;
            }
            
            ++needleIndex;
            ++haystackIndex;
        }
        
        return needle.Length == needleIndex;
    }
}