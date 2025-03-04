public class Solution {
    public IList<IList<int>> Subsets(int[] nums) => this.Get(nums, new List<IList<int>>(), new Stack<int>(), 0);
    
    private IList<IList<int>> Get(int[] nums, IList<IList<int>> output, Stack<int> current, int index) {
        if (nums.Length == index) {
            output.Add(current.ToList());
        }
        else {
            current.Push(nums[index]);
            ++index;
            
            output = this.Get(nums, output, current, index);
            
            current.Pop();
            
            output = this.Get(nums, output, current, index);
        }
        
        return output;
    }
}