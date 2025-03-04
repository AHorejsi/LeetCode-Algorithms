public class Solution {
    private static readonly HashSet<char> StartChars = new HashSet<char>() { '[', '(', '{' };
    private static readonly Dictionary<char, char> EndChars = new Dictionary<char, char>() { { ']', '['}, { ')', '(' }, { '}', '{' } };
    
    public bool IsValid(string str) {
        Stack<char> stack = new Stack<char>();
        
        foreach (char ch in str) {
            if (Solution.StartChars.Contains(ch)) {
                stack.Push(ch);
            }
            else {
                if (0 == stack.Count) {
                    return false;
                }
                else {
                    char top = stack.Peek();
                    char other;
                    
                    if (Solution.EndChars.TryGetValue(ch, out other) && top == other) {
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