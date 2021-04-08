public class Solution {
    public int CountPrimes(int high) {
        bool[] prime = this.FindPrimes(high);
        int primeCount = this.CountPrimes(prime);
        
        return primeCount;
    }
    
    private bool[] FindPrimes(int high) {
        bool[] prime = new bool[high];
        Array.Fill(prime, true);
        
        int end = (int)Math.Sqrt(prime.Length);
        
        for (int i = 2; i <= end; ++i) {
            if (prime[i]) {
                for (int j = i * i; j < high; j += i) {
                    prime[j] = false;
                }
            }
        }
        
        return prime;
    }
    
    private int CountPrimes(bool[] prime) {
        int count = 0;
        
        for (int i = 2; i < prime.Length; ++i) {
            if (prime[i]) {
                ++count;
            }
        }
        
        return count;
    }
}