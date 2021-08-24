public class Solution {
    public bool IsPalindrome(string str) {
        int left = 0;
        int right = str.Length - 1;
        
        int validCount = str.Count((char ch) => char.IsLetter(ch) || char.IsNumber(ch));
        
        while (left < right) {
            char leftCurrent = str[left];
            char rightCurrent = str[right];
            
            while (!(char.IsLetter(str[left]) || char.IsNumber(str[left]))) {
                ++left;
                
                if (left == right) {
                    return true;
                }
            }
            
            while (!(char.IsLetter(str[right]) || char.IsNumber(str[right]))) {
                --right;
                
                if (left == right) {
                    return true;
                }
            }
            
            if (char.ToLower(str[left]) == char.ToLower(str[right])) {
                ++left;
                --right;
            }
            else {
                return false;
            }
        }
        
        return true;
    }
}