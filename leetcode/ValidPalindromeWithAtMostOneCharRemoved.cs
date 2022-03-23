public class Solution {
    public bool ValidPalindrome(string str) => this.ValidPalindrome(str, 0, str.Length - 1, false);
    
    // "str" - The string to be checked for being a palindrome or being a palindrome if one char is removed
    // "leftIndex" - The leftside char to be compared to the rightside char
    // "rightIndex" - The rightside char to be compared to the left side char
    // "charRemoved" - Indicates whether or not a char has been chosen to be ignored due to some previous recursive call
    private bool ValidPalindrome(string str, int leftIndex, int rightIndex, bool charRemoved) {
        // WE point to two elements specified by "leftIndex" and "rightIndex." Check if the two elements
        // in question are equal. If the two elements are not equal, then we try removing a char to see
        // if a palindrome can be produced that way
        
        while (leftIndex < rightIndex) {
            if (str[leftIndex] == str[rightIndex]) {
                // The two chars that are being pointed to right now are equal.
                // Move both pointers inward and ignore neither
                
                ++leftIndex;
                --rightIndex;
            }
            else {
                if (charRemoved) {
                    // If a char was removed by some previous recursive call, then we cannot remove
                    // the selected, ignored char because we would have to remove more for there
                    // to be a palindrome
                    
                    return false;
                }
                
                if (
                    str[leftIndex + 1] == str[rightIndex] && this.ValidPalindrome(str, leftIndex + 2, rightIndex - 1, true) ||
                    str[leftIndex] == str[rightIndex - 1] && this.ValidPalindrome(str, leftIndex + 1, rightIndex - 2, true)
                ) {
                    // If the char to the right of "leftIndex" equals the char at "rightIndex", it is possible we could remove the
                    // char at "leftIndex" and continue checking if the rest of the string is a palindrome. Also, if the char to the left
                    // of "rightIndex" equals the char at "leftIndex", it is possible we could remove the char at "rightIndex" and continue
                    // checking if the rest of the string is a palindrome
                    
                    return true;
                }
                
                // If we fail to find a palindrome after removing a char, there is no palindrome with at most one char removed
                return false;
            }
        }
        
        // The indices "leftIndex" and "rightIndex" have crossed if this is reached. Therefore, a
        // palindrome has been found
        return true;
    }
}
