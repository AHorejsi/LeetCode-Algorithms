public class Solution {
    public string AddStrings(string num1, string num2) {
        StringBuilder result = new StringBuilder();
        
        int indexOfNum1 = num1.Length - 1;
        int indexOfNum2 = num2.Length - 1;
        
        bool carryOne = false;
        
        while (indexOfNum1 >= 0 || indexOfNum2 >= 0) {
            char digit1 = this.GetDigit(num1, indexOfNum1);
            char digit2 = this.GetDigit(num2, indexOfNum2);
            
            int digit1AsInt = digit1 - '0';
            int digit2AsInt = digit2 - '0';
            int sum = digit1AsInt + digit2AsInt;
            
            if (carryOne) {
                ++sum;
            }
            
            if (sum >= 10) {
                result.Append(sum - 10);
                carryOne = true;
            }
            else {
                result.Append(sum);
                carryOne = false;
            }
            
            --indexOfNum1;
            --indexOfNum2;
        }
        
        if (carryOne) {
            result.Append(1);
        }
        
        return this.Reverse(result);
    }
    
    private char GetDigit(string num, int index) => (index < 0) ? '0' : num[index];
    
    private string Reverse(StringBuilder sb) {
        StringBuilder result = new StringBuilder();
        
        for (int index = sb.Length - 1; index >= 0; --index) {
            result.Append(sb[index]);
        }
        
        return result.ToString();
    }
}