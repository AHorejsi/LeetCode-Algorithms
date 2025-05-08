public class Solution {
    private const int EMPTY = -1;

    public int Rob(int[] nums) {
        var moneySum = int.MinValue;
        var seen = new int[nums.Length];

        Array.Fill(seen, EMPTY);
        
        for (var index = 0; index < nums.Length; ++index) {
            var newMoneySum = this.RobHelper(nums, index, seen);

            if (newMoneySum > moneySum) {
                moneySum = newMoneySum;
            }
        }

        return moneySum;
    }

    private int RobHelper(int[] nums, int index, int[] seen) {
        if (EMPTY != seen[index]) {
            return seen[index];
        }

        var currentMoneySum = nums[index];
        var finalMoneySum = currentMoneySum;

        for (var nextIndex = index + 2; nextIndex < nums.Length; ++nextIndex) {
            var newMoneySum = currentMoneySum + this.RobHelper(nums, nextIndex, seen);

            if (newMoneySum > finalMoneySum) {
                finalMoneySum = newMoneySum;
            }
        }

        seen[index] = finalMoneySum;

        return finalMoneySum;
    }
}
