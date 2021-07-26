public class Solution {
    public int HIndex(int[] citations) {
        int lowIndex = 0;
        int highIndex = citations.Length - 1;
        
        int hIndex = 0;
        
        while (lowIndex <= highIndex) {
            int midIndex = lowIndex + (highIndex - lowIndex) / 2;
            int potentialHIndex = citations.Length - midIndex;
            
            if (citations[midIndex] >= potentialHIndex) {
                hIndex = potentialHIndex;
                
                highIndex = midIndex - 1;
            }
            else {
                lowIndex = midIndex + 1;
            }
        }
        
        return hIndex;
    }
}