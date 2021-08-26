public class Solution {
    public int Compress(char[] chars) {
        int startIndex = 0;
        int writeIndex = 0;
        
        while (startIndex < chars.Length) {
            int length = this.GroupLength(chars, startIndex);
            
            chars[writeIndex] = chars[startIndex];
            ++writeIndex;
            
            if (1 != length) {
                foreach (char digit in length.ToString()) {
                    chars[writeIndex] = digit;
                    ++writeIndex;
                }
            }
            
            startIndex += length;
        }
        
        return writeIndex;
    }
    
    private int GroupLength(char[] chars, int startIndex) {
        int index = startIndex + 1;
        
        while (index < chars.Length && chars[index] == chars[startIndex]) {
            ++index;
        }
        
        return index - startIndex;
    }
}