public class Solution {
    public int ShortestDistance(string[] words, string word1, string word2) {        
        int wordCount = words.Length;
        
        int indexOfWord1 = -1;
        int indexOfWord2 = -1;
        
        int distance = int.MaxValue;
        
        for (int index = 0; index < wordCount; ++index) {
            string current = words[index];
            
            if (current == word1) {
                indexOfWord1 = index;
            }
            else if (current == word2) {
                indexOfWord2 = index;
            }
            else {
                continue;
            }
            
            if (-1 != indexOfWord1 && -1 != indexOfWord2) {
                distance = Math.Min(distance, Math.Abs(indexOfWord1 - indexOfWord2));
            }
        }
        
        return distance;
    }
}