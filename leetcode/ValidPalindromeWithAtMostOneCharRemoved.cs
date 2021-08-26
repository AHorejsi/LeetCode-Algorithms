public class Solution {
    public bool ValidPalindrome(string str) {
        int start = 0;
        int end = str.Length - 1;
        bool charRemoved = false;
        
        while (start < end) {
            if (str[start] == str[end]) {
                ++start;
                --end;
            }
            else {
                if (charRemoved) {
                    return false;
                }
                else {
                    if (str[start + 1] == str[end]) {
                        if (str[start] == str[end - 1] && this.CheckRange(str, start + 1, end - 2)) {
                            return true;
                        }
                        else {
                            ++start;
                        }
                    }
                    else {
                        --end;
                    }
                    
                    charRemoved = true;
                }
            }
        }
        
        return true;
    }
    
    private bool CheckRange(string str, int start, int end) {
        while (start < end) {
            if (str[start] == str[end]) {
                ++start;
                --end;
            }
            else {
                return false;
            }
        }
        
        return true;
    }
}