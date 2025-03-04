public class Solution {
    public string MinRemoveToMakeValid(string str) {
        StringBuilder result = new StringBuilder();
        
        Stack<int> stack = new Stack<int>();
        
        foreach (char elem in str) {
            if (Char.IsLetter(elem)) {
                result.Append(elem);
            }
            else {
                if ('(' == elem) {
                    stack.Push(result.Length);
                    result.Append(elem);
                }
                else if (')' == elem && 0 != stack.Count) {
                    stack.Pop();
                    result.Append(elem);
                }
            }
        }
        
        this.RemoveUnclosedParentheses(result, stack);
        
        return result.ToString();
    }
    
    private void RemoveUnclosedParentheses(StringBuilder result, Stack<int> stack) {
        while (0 != stack.Count) {
            int index = stack.Pop();
            
            result.Remove(index, 1);
        }
    }
}