public class Solution {
    public int Trap(int[] heights) {
        if (heights is null || 0 == heights.Length) {
            return 0;
        }
        
        int result = 0;
        
        int[] leftMax = new int[heights.Length];
        int[] rightMax = new int[heights.Length];
        
        leftMax[0] = heights[0];
        for (int index = 1; index < heights.Length; ++index) {
            leftMax[index] = Math.Max(heights[index], leftMax[index - 1]);
        }
        
        rightMax[heights.Length - 1] = heights[heights.Length - 1];
        for (int index = heights.Length - 2; index >= 0; --index) {
            rightMax[index] = Math.Max(heights[index], rightMax[index + 1]);
        }
        
        for (int index = 1; index < heights.Length - 1; ++index) {
            result += Math.Min(leftMax[index], rightMax[index]) - heights[index];
        }
        
        return result;
    }
}