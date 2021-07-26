public class Solution {
    public string ReverseWords(string str) {
        if (0 == str.Length) {
            return "";
        }
        
        Stack<string> stack = this.BuildStack(str);
        StringBuilder sb = new StringBuilder();
        
        while (1 != stack.Count) {
            sb.Append(stack.Pop());
            sb.Append(' ');
        }
        
        sb.Append(stack.Pop());
        
        return sb.ToString();
    }
    
    private Stack<string> BuildStack(string str) {
        Stack<string> stack = new Stack<string>();
        StringBuilder sb = new StringBuilder();
        
        foreach (char value in str) {
            if (' ' == value) {
                if (0 != sb.Length) {
                    stack.Push(sb.ToString());
                    sb.Clear();
                }
            }
            else {
                sb.Append(value);
            }
        }
        
        if (0 != sb.Length) {
            stack.Push(sb.ToString());
        }
        
        return stack;
    }
}