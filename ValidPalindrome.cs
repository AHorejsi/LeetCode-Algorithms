public class Solution {
    public bool IsPalindrome(string str) {
        StringBuilder sanitized = this.SanitizeInput(str);
        
        int leftIndex = 0;
        int rightIndex = sanitized.Length - 1;
        
        while (leftIndex < rightIndex) {
            if (sanitized[leftIndex] != sanitized[rightIndex]) {
                return false;
            }
            
            ++leftIndex;
            --rightIndex;
        }
        
        return true;
    }
    
    private StringBuilder SanitizeInput(string str) {
        StringBuilder sb = new StringBuilder(str.Length);
        
        foreach (char elem in str) {
            if (Char.IsLetter(elem)) {
                sb.Append(Char.ToLower(elem));
            }
            else if (Char.IsNumber(elem)) {
                sb.Append(elem);
            }
        }
        
        return sb;
    }
}