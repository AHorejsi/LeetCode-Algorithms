public class Solution {
    public string IntToRoman(int num) {
        StringBuilder result = new StringBuilder();
        
        this.ThousandsPlace(result, ref num);
        this.HundredsPlace(result, ref num);
        this.TensPlace(result, ref num);
        this.OnesPlace(result, ref num);
        
        return result.ToString();
    }
    
    private void ThousandsPlace(StringBuilder result, ref int num) {
        int factor = 1000;
        
        if (num >= factor) {
            int place = num / factor;
            
            for (int temp = 0; temp < place; ++temp) {
                result.Append('M');
            }
            
            num -= place * factor;
        }
    }
    
    private void HundredsPlace(StringBuilder result, ref int num) {
        int factor = 100;
        
        if (num >= factor) {
            int place = num / factor;
            
            if (4 == place) {
                result.Append("CD");
            }
            else if (9 == place) {
                result.Append("CM");
            }
            else {
                int temp = place;
                
                if (temp >= 5) {
                    result.Append('D');
                    temp -= 5;
                }
                
                while (temp > 0) {
                    result.Append('C');
                    --temp;
                }
            }
            
            num -= place * factor;
        }
    }
    
    private void TensPlace(StringBuilder result, ref int num) {
        int factor = 10;
        
        if (num >= factor) {
            int place = num / factor;
            
            if (4 == place) {
                result.Append("XL");
            }
            else if (9 == place) {
                result.Append("XC");
            }
            else {
                int temp = place;
                
                if (temp >= 5) {
                    result.Append('L');
                    temp -= 5;
                }
                
                while (temp > 0) {
                    result.Append('X');
                    --temp;
                }
            }
            
            num -= place * factor;
        }
    }
    
    private void OnesPlace(StringBuilder result, ref int num) {
        if (4 == num) {
            result.Append("IV");
        }
        else if (9 == num) {
            result.Append("IX");
        }
        else {
            if (num >= 5) {
                result.Append('V');
                num -= 5;
            }
            
            while (num > 0) {
                result.Append('I');
                --num;
            }
        }
    }
}