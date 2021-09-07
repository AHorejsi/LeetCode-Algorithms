public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int max = amount + 1;
        int[] dp = new int[max];
        
        Array.Fill(dp, max, 1, dp.Length - 1);
        
        for (int i = 1; i < max; ++i) {
            for (int j = 0; j < coins.Length; ++j) {
                if (coins[j] <= i) {
                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }
        }
        
        return dp[amount] > amount ? -1 : dp[amount];
    }
}