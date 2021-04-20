public class Solution {
    public int Reverse(int num) {
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