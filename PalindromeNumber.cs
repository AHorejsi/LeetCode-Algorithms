public class Solution {
    public bool IsPalindrome(int num) {
        if (num < 0) {
            return false;
        }
        
        return this.Reverse(num) == num;
    }
    
    private int Reverse(int num) {
        int reverseNum = 0;
        
        while (num != 0) {
            int pop = num % 10;
            num /= 10;
            
            if (reverseNum > int.MaxValue / 10 || (reverseNum == int.MaxValue / 10 && pop > 7)) { 
                return 0;
            }
            
            reverseNum = reverseNum * 10 + pop;
        }
        
        return reverseNum;
    }
}