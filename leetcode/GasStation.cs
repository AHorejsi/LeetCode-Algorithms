public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int stationCount = gas.Length;
        
        int totalTank = 0;
        int currentTank = 0;
        int startStation = 0;
        
        for (int index = 0; index < stationCount; ++index) {
            int amount = gas[index] - cost[index];
            
            totalTank += amount;
            currentTank += amount;
            
            if (currentTank < 0) {
                startStation = index + 1;
                currentTank = 0;
            }
        }
        
        return totalTank < 0 ? -1 : startStation;
    }
}