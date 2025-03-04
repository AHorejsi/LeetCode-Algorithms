public class Solution {
    public bool IsSubsequence(string str1, string str2) {
        IEnumerator<char> chars1 = str1.GetEnumerator();
        IEnumerator<char> chars2 = str2.GetEnumerator();
        
        bool more = chars1.MoveNext();
        
        while (more && chars2.MoveNext()) {
            if (chars1.Current == chars2.Current) {
                more = chars1.MoveNext();
            }
        }
        
        return !more;
    }
}