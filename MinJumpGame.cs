public class Solution {    
    public int Jump(int[] nums) {
        int lastIndex = nums.Length - 1;

        Dictionary<int, int> results = new Dictionary<int, int>(nums.Length);
        results.Add(lastIndex, 0);

        this.MinJumps(nums, 0, results);

        return results[0];
    }
    
    private int MinJumps(int[] nums, int index, Dictionary<int, int> distances) {
        if (distances.ContainsKey(index)) {
            return distances[index];
        }
        else {
            int minDistanceFromIndex = int.MaxValue - 1;
            
            for (int stepSize = nums[index]; stepSize > 0; --stepSize) {
                int nextIndex = index + stepSize;
                
                if (nextIndex < nums.Length) {
                    int distanceOfCurrent = this.MinJumps(nums, nextIndex, distances) + 1;
                        
                    if (minDistanceFromIndex > distanceOfCurrent) {
                        minDistanceFromIndex = distanceOfCurrent;
                    }
                }
            }
            
            distances.Add(index, minDistanceFromIndex);
            
            return minDistanceFromIndex;
        }
    }
}