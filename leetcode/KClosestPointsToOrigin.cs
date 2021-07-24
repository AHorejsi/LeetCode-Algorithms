public class Solution {
    public int[][] KClosest(int[][] points, int k) => points.OrderBy(point => this.DistanceFromOrigin(point)).Take(k).ToArray();
    
    private double DistanceFromOrigin(int[] point) => Math.Sqrt(point[0] * point[0] + point[1] * point[1]);
}