public class Solution {
    private static readonly Random rand = new Random();
    private Dictionary<int, List<int>> indices;

    public Solution(int[] nums) {
        this.indices = new Dictionary<int, List<int>>();
        
        for (int index = 0; index < nums.Length; ++index) {
            List<int> listOfIndices;
            if (this.indices.TryGetValue(nums[index], out listOfIndices)) {
                listOfIndices.Add(index);
            }
            else {
                this.indices.Add(nums[index], new List<int>() { index });
            }
        }
    }
    
    public int Pick(int target) {
        List<int> indicesOfTarget = this.indices[target];
        int selectedIndex = Solution.rand.Next(indicesOfTarget.Count);
        
        return indicesOfTarget[selectedIndex];
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int param_1 = obj.Pick(target);
 */