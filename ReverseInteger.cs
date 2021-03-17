public class Solution {
    public int Reverse(int num) {
        int reverseNum = 0;
        
        while (num != 0) {
            int digit = num % 10;
            num /= 10;
            
            if (reverseNum > int.MaxValue / 10 || (reverseNum == int.MaxValue / 10 && digit > 7)) { 
                return 0;
            }
            if (reverseNum < int.MinValue / 10 || (reverseNum == int.MinValue / 10 && digit < -8)) {
                return 0;
            }
            
            reverseNum = reverseNum * 10 + digit;
        }
        
        return reverseNum;
    }
}