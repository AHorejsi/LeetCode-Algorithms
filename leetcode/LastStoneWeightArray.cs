public class Solution {
    public int LastStoneWeight(int[] stones) {
        var indices = new List<int>();

        while (true) {
            this.FindStones(stones, indices);

            if (indices.Count <= 1) {
                break;
            }

            (var maxIndex1, var maxIndex2) = this.FindMaxStones(stones, indices);

            if (stones[maxIndex1] <= stones[maxIndex2]) {
                stones[maxIndex2] = stones[maxIndex2] - stones[maxIndex1];
                stones[maxIndex1] = 0;
            }
            else {
                stones[maxIndex1] = stones[maxIndex1] - stones[maxIndex2];
                stones[maxIndex2] = 0;
            }

            indices.Clear();
        }

        return indices.Any() ? stones[indices.Single()] : 0;
    }

    private void FindStones(int[] stones, IList<int> indices) {
        var length = stones.Length;

        for (var index = 0; index < length; ++index) {
            if (0 != stones[index]) {
                indices.Add(index);
            }
        }
    }

    private (int, int) FindMaxStones(int[] stones, IList<int> indices) {
        var maxIndex1 = this.Find1stMax(stones, indices);
        var maxIndex2 = this.Find2ndMax(stones, indices, maxIndex1);

        return (maxIndex1, maxIndex2);
    }

    private int Find1stMax(int[] stones, IList<int> indices) {
        var maxValue1 = int.MinValue;
        var maxIndex1 = -1;

        foreach (var index in indices) {
            if (stones[index] > maxValue1) {
                maxValue1 = stones[index];
                maxIndex1 = index;
            }
        }

        return maxIndex1;
    }

    private int Find2ndMax(int[] stones, IList<int> indices, int maxIndex1) {
        var maxValue2 = int.MinValue;
        var maxIndex2 = -1;

        foreach (var index in indices) {
            if (index != maxIndex1) {
                if (stones[index] > maxValue2) {
                    maxValue2 = stones[index];
                    maxIndex2 = index;
                }
            }
        }

        return maxIndex2;
    }
}
