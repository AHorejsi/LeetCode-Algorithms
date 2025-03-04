public class Solution {
    private static readonly Dictionary<char, char[]> map = new Dictionary<char, char[]>();
    
    static Solution() {
        Solution.map.Add('2', new char[] { 'a', 'b', 'c' });
        Solution.map.Add('3', new char[] { 'd', 'e', 'f' });
        Solution.map.Add('4', new char[] { 'g', 'h', 'i' });
        Solution.map.Add('5', new char[] { 'j', 'k', 'l' });
        Solution.map.Add('6', new char[] { 'm', 'n', 'o' });
        Solution.map.Add('7', new char[] { 'p', 'q', 'r', 's' });
        Solution.map.Add('8', new char[] { 't', 'u', 'v' });
        Solution.map.Add('9', new char[] { 'w', 'x', 'y', 'z' });
    }
    
    public IList<string> LetterCombinations(string digits) {
        List<string> combos = new List<string>();
        
        if (0 != digits.Length) {
            this.FindCombos(digits, combos, new StringBuilder(digits.Length), 0);
        }
        
        return combos;
    }
    
    private void FindCombos(string digits, List<string> combos, StringBuilder current, int index) {
        if (digits.Length == index) {
            string result = current.ToString();
            combos.Add(result);
        }
        else {
            char[] letters = Solution.map[digits[index]];
            
            foreach (char ch in letters) {
                current.Append(ch);
                this.FindCombos(digits, combos, current, index + 1);
                current.Remove(current.Length - 1, 1);
            }
        }
    }
}