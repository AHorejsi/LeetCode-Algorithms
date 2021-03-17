public class Solution {
    public int MyAtoi(string str) {
        if (0 == str.Length) {
            return 0;
        }
        
        int index = 0;
        
        while (index < str.Length && ' ' == str[index]) {
            ++index;
        }
        
        if (index == str.Length) {
            return 0;
        }
        
        bool isNegative;
        
        if ('-' == str[index]) {
            isNegative = true;
            ++index;
        }
        else if ('+' == str[index]) {
            isNegative = false;
            ++index;
        }
        else {
            isNegative = false;
        }
        
        int result = 0;
        int factor = 10;
        
        while (index < str.Length && Char.IsNumber(str[index])) {
            int charNumber = str[index] - '0';

            try {
                result = checked(result * factor + charNumber);
            } catch (OverflowException ex) {
                return isNegative ? int.MinValue : int.MaxValue;
            }
            
            ++index;
        }
        
        return isNegative ? -result : result;
    }
}