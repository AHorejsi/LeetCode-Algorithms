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
        if (num >= 1000) {
            int place = num / 1000;
            
            for (int temp = 0; temp < place; ++temp) {
                result.Append('M');
            }
            
            num -= place * 1000;
        }
    }
    
    private void HundredsPlace(StringBuilder result, ref int num) {
        if (num >= 100) {
            int place = num / 100;
            
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
            
            num -= place * 100;
        }
    }
    
    private void TensPlace(StringBuilder result, ref int num) {
        if (num >= 10) {
            int place = num / 10;
            
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
            
            num -= place * 10;
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