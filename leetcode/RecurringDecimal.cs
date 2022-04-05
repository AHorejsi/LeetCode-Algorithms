public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        // Flag that tracks whether or not the output shall contain a negative sign
        bool isNegative = 0 != numerator && numerator < 0 ^ denominator < 0;
        
        // Convert both "numerator" and "denominator" to positive so we can ignore sign
        // during computation of the decimal part
        long longNumerator = Math.Abs((long)numerator);
        long longDenominator = Math.Abs((long)denominator);
        
        // Compute the integer part of the output
        string integerPart = (longNumerator / longDenominator).ToString();
        
        // Compute the decimal part of the output with the repeating
        // part wrapped in parentheses
        string decimalPart = this.ComputeDecimalPart(longNumerator, longDenominator);
        
        // Ignore the decimal part if it is equal to zero, otherwise
        // include both in output
        string num = 0 == decimalPart.Length ? $"{integerPart}" : $"{integerPart}.{decimalPart}";
        
        // Check "isNegative" flag for whether or not negative sign shall be added
        string signedNum = isNegative ? $"-{num}" : num;
        
        return signedNum;
    }
    
    private string ComputeDecimalPart(long numerator, long denominator) {        
        string decimalPart = "";
        
        Dictionary<long, int> seen = new Dictionary<long, int>();
        long remainder = numerator % denominator;
        
        while (0 != remainder && !seen.ContainsKey(remainder)) {
            seen.Add(remainder, decimalPart.Length);
            
            remainder *= 10;
            
            long remainderPart = remainder / denominator;
            
            decimalPart += remainderPart.ToString();
            
            remainder %= denominator;
        }
        
        if (0 == remainder) {
            // If "remainder" is ever zero, then there is not sequence of infinitely
            // repeating digits. Return only the computed decimal portion with no elements
            // wrapped in parentheses
            
            return $"{decimalPart}";
        }
        else {
            // If "remainder" is not zero, then there is a sequence of infinitely
            // repeating digits. Wrap the repeating sequence in parentheses
            
            int split = seen[remainder];
            
            string nonrepeat = decimalPart.Substring(0, split);
            string repeat = decimalPart.Substring(split);
            
            return $"{nonrepeat}({repeat})";
        }
    }
}
