public class Solution {
    public int LengthOfLastWord(string sentence) {
        var last = sentence
            .Split(' ', StringSplitOptions.RemoveEmptyEntries) // Get the individual words of the string
            .Last(); // Of the individual words, pull out the last one

        return last.Length;
    }
}
