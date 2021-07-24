public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit = 0;
       
        for (int index = 1; index < prices.Length; ++index) {
            if (prices[index] > prices[index - 1]) {
                maxProfit += prices[index] - prices[index - 1];
            }
        }
        
        return maxProfit;
    }
}