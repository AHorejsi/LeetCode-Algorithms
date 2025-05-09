public class Solution {
    public int Rob(int[] nums) {
        if (1 == nums.Length) {
            return nums[0];
        }

        var length = nums.Length;
        var solutions = new int[length];

        solutions[0] = nums[0];
        solutions[1] = Math.Max(nums[0], nums[1]);

        for (var index = 2; index < length; ++index) {
            solutions[index] = Math.Max(solutions[index - 1], nums[index] + solutions[index - 2]);
        }

        return solutions[length - 1];
    }
}
