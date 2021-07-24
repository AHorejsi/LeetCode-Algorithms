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
            
            try {
				reverseNum = checked(reverseNum * 10 + pop);
			} catch (OverflowException ex) {
				return 0;
			}
        }
        
        return reverseNum;
    }
}