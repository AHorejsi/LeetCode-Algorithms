public class Solution {
    private static Dictionary<string, int> numberMap = new Dictionary<string, int>();
    
    static Solution() {
        numberMap.Add("I", 1);
        numberMap.Add("IV", 4);
        numberMap.Add("V", 5);
        numberMap.Add("IX", 9);
        numberMap.Add("X", 10);
        numberMap.Add("XL", 40);
        numberMap.Add("L", 50);
        numberMap.Add("XC", 90);
        numberMap.Add("C", 100);
        numberMap.Add("CD", 400);
        numberMap.Add("D", 500);
        numberMap.Add("CM", 900);
        numberMap.Add("M", 1000);
    }
    
    public int RomanToInt(string str) {
        int index = str.Length - 1;
        int result = 0;
        
        while (index >= 0) {
            if (0 != index) {
                string lastTwo = str.Substring(index - 1, 2);
                
                int num;
                bool success = Solution.numberMap.TryGetValue(lastTwo, out num);

                if (success) {
                    result += num;
                    index -= 2;
                    
                    continue;
                }
            }
            
            string lastOne = str.Substring(index, 1);

            result += Solution.numberMap[lastOne];

            --index;
        }
        
        return result;
    }
}