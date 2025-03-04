public class Solution {
    public int[][] KClosest(int[][] points, int k) =>
        points.OrderBy(point => Math.Sqrt(point[0] * point[0] + point[1] * point[1])).Take(k).ToArray();
}
