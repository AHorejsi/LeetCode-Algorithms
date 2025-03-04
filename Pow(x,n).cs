public class Solution {
    public double MyPow(double num, int exponent) {
        bool negativeExponent;
        
        if (exponent < 0) {
            negativeExponent = true;
            exponent = -exponent;
        }
        else {
            negativeExponent = false;
        }
        
        double result = this.FastPow(num, exponent);
        
        return negativeExponent ? 1 / result : result;
    }
    
    private double FastPow(double num, int exponent) {
        if (0 == exponent) {
            return 1;
        }
        
        double half = this.FastPow(num, exponent / 2);
        
        return (0 == exponent % 2) ? half * half : half * half * num;
    }
}