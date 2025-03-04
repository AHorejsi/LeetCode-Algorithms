public class Solution {    
    public int MaxCoins(int[] array) {
        array = array.Where((int num) => 0 != num).Prepend(1).Append(1).ToArray();
        int size = array.Length;
        int endIndex = size - 1;
        int[,] dp = new int[size, size];
        
        for (int length = 1; length < endIndex; ++length) {
            int lengthEnd = endIndex - length;
            
            for (int left = 0; left < lengthEnd; ++left) {
                int right = left + length + 1;
                
                for (int i = left + 1; i < right; ++i) {
                    dp[left, right] = Math.Max(dp[left, right], array[left] * array[i] * array[right] + dp[left, i] + dp[i, right]);
                }
            }
        }
        
        return dp[0, endIndex];
    }
}