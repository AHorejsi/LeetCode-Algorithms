public class Solution {    
    public IList<IList<int>> ThreeSum(int[] nums) {
        nums = nums.OrderBy(x => x).ToArray();
        
        IList<IList<int>> result = new List<IList<int>>();
        
        for (int i = 0; i < nums.Length && nums[i] <= 0; ++i) {
            if (0 == i || nums[i - 1] != nums[i]) {
                this.Search(i, nums, result);
            }
        }
        
        return result;
    }
    
    private void Search(int i, int[] nums, IList<IList<int>> result) {
        int low = i + 1;
        int high = nums.Length - 1;
        
        while (low < high) {
            int sum = nums[i] + nums[low] + nums[high];
            
            if (sum < 0) {
                ++low;
            }
            else if (sum > 0) {
                --high;
            }
            else {
                result.Add(new List<int> { nums[i], nums[low], nums[high] });
                
                ++low;
                --high;
                
                while (low < high && nums[low] == nums[low - 1]) {
                    ++low;
                }
            }
        }
    }
}