public class Solution {
    public bool IsValid(string str) {
        var stack = new Stack<char>();
        
        foreach (char ch in str) {
            if ('[' == ch || '(' == ch || '{' == ch) {
                stack.Push(ch);
            }
            else {
                if (0 == stack.Count) {
                    return false;
                }
                else {
                    char top = stack.Peek();
                    
                    if (']' == ch && top == '[' || ')' == ch && top == '(' || '}' == ch && top == '{') {
                        stack.Pop();
                    }
                    else {
                        return false;
                    }
                }
            }            
        }
        
        return 0 == stack.Count;
    }
}