public class Solution {
    public int MinDistance(string word1, string word2) {
        if (0 == word1.Length) {
            return word2.Length;
        }
        else if (0 == word2.Length) {
            return word1.Length;
        }
        
        int rows = word1.Length + 1;
        int cols = word2.Length + 1;
        
        int[,] conversions = new int[rows, cols];
        
        for (int i = 1; i < rows; ++i) {
            conversions[i, 0] = i;
        }
        
        for (int j = 1; j < cols; ++j) {
            conversions[0, j] = j;
        }
        
        for (int i = 1; i < rows; ++i) {
            for (int j = 1; j < cols; ++j) {
                if (word1[i - 1] == word2[j - 1]) {
                    conversions[i, j] = conversions[i - 1, j - 1];
                }
                else {
                    int left = conversions[i, j - 1];
                    int up = conversions[i - 1, j];
                    int leftUp = conversions[i - 1, j - 1];
                    
                    conversions[i, j] = 1 + Math.Min(left, Math.Min(up, leftUp));
                }
            }
        }
        
        return conversions[word1.Length, word2.Length];
    }
}