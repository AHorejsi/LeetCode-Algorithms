public class Solution {
    public string LongestPalindrome(string str) {
        bool[,] table = new bool[str.Length, str.Length];
        
        int start = 0;
        int maxLength = 1;
        
        for (int i = 0; i < str.Length; ++i) {
            table[i, i] = true;
        }
        
        for (int i = 0; i < str.Length - 1; ++i) {
            if (str[i] == str[i + 1]) {
                table[i, i + 1] = true;
                start = i;
                maxLength = 2;
            }
        }
        
        for (int length = 3; length <= str.Length; ++length) {
            for (int i = 0; i < str.Length - length + 1; ++i) {
                int j = i + length - 1;
                
                if (table[i + 1, j - 1] && str[i] == str[j]) {
                    table[i, j] = true;
                    
                    if (length > maxLength) {
                        start = i;
                        maxLength = length;
                    }
                }
            }
        }
        
        return str.Substring(start, maxLength);
    }
}