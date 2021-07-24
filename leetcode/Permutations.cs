public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> permutations = new List<IList<int>>();
        this.MakePermutations(nums, permutations, 0);
        
        return permutations;
    }
    
    private void MakePermutations(int[] nums, IList<IList<int>> permutations, int index) {
        if (index == nums.Length) {
            permutations.Add(this.CopyNums(nums));
        }
        else {
            for (int i = index; i < nums.Length; ++i) {
                this.Swap(nums, i, index);
                
                this.MakePermutations(nums, permutations, index + 1);
                
                this.Swap(nums, i, index);
            }
        }
    }
    
    private void Swap(int[] nums, int i, int j) {
        if (i != j) {
            nums[i] ^= nums[j];
            nums[j] ^= nums[i];
            nums[i] ^= nums[j];
        }
    }
    
    private int[] CopyNums(int[] nums) {
        int[] copyNums = new int[nums.Length];
        Array.Copy(nums, copyNums, nums.Length);
        
        return copyNums;
    }
}