public class Solution {
    public int MaxArea(int[] heights) {
        int maxArea = 0;
        
        int left = 0;
        int right = heights.Length - 1;
        
        while (left < right) {
            int height = Math.Min(heights[left], heights[right]);
            int width = right - left;
            
            maxArea = Math.Max(maxArea, height * width);
            
            if (heights[left] <= heights[right]) {
                ++left;
            }
            else {
                --right;
            }
        }
        
        return maxArea;
    }
}