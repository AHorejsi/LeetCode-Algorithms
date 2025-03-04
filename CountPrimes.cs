public class Solution {
    public int CountPrimes(int high) {
        if (high <= 2) {
            return 0;
        }
        
        bool[] prime = new bool[high];
        this.Fill(prime);
        
        int end = (int)Math.Sqrt(prime.Length);
        
        for (int i = 2; i <= end; ++i) {
            if (prime[i]) {
                for (int j = i * i; j < high; j += i) {
                    prime[j] = false;
                }
            }
        }
        
        return prime.Count(true);
    }
    
    private void Fill(bool[] prime) {
        for (int i = 2; i < prime.Length; ++i) {
            prime[i] = true;
        }
    }
}