public class Solution {
    public int Trap(int[] heights) {
        if (heights is null) {
            return 0;
        }
        
        int result = 0;
        Stack<int> stack = new Stack<int>();
        
        int current = 0;
        
        while (current < heights.Length) {
            while (0 != stack.Count && heights[current] > heights[stack.Peek()]) {
                int top = stack.Pop();
                
                if (0 == stack.Count) {
                    break;
                }
                
                int distance = current - stack.Peek() - 1;
                int boundedHeight = Math.Min(heights[current], heights[stack.Peek()]) - heights[top];
                result += distance * boundedHeight;
            }
            
            stack.Push(current);
            ++current;
        }
       
        return result;
    }
}