public class Solution {
    // There is only one char that separates the words in the string
    // This is that separator char
    private const char Separator = ' ';
    
    public void ReverseWords(char[] str) {
        // Reverse the whole string. Doing this places the
        // the substrings that represent the individual
        // words in the correct spots, but the individual
        // words are in reverse order. After this, we will
        // reverse the individual words
        this.Reverse(str, 0, str.Length - 1);
        
        // Index of the leftmost char of the current word
        int leftIndex = 0;
        
        while (leftIndex < str.Length) {
            // Index of the rightmost char of the current word
            int rightIndex = leftIndex + 1;
            
            // Finds the next space in the whole string so that "rightIndex" can be used
            // to specify what range of indices to reverse
            while (str.Length != rightIndex && Solution.Separator != str[rightIndex]) {
                ++rightIndex;
            }
            
            // Reverse the substring represented by "leftIndex" and "rightIndex."
            // The "- 1" is there because "rightIndex" currently points to a separator char
            this.Reverse(str, leftIndex, rightIndex - 1);
            
            // Move "leftIndex" to the right of the last found separator char
            leftIndex = rightIndex + 1;
        }
    }
    
    // Simple array reverse function
    private void Reverse(char[] str, int leftIndex, int rightIndex) {
        while (leftIndex < rightIndex) {
            this.Swap(str, leftIndex, rightIndex);
            
            ++leftIndex;
            --rightIndex;
        }
    }
    
    // Bitwise swap function
    private void Swap(char[] str, int index1, int index2) {
        if (str[index1] != str[index2]) {
            str[index1] ^= str[index2];
            str[index2] ^= str[index1];
            str[index1] ^= str[index2];
        }
    }
}
