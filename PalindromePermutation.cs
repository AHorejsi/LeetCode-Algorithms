public class Solution {
    public bool CanPermutePalindrome(string str) {
        HashSet<char> set = new HashSet<char>();
        
        foreach (char elem in str) {
            if (!set.Add(elem)) {
                set.Remove(elem);
            }
        }
        
        return set.Count <= 1;
    }
}